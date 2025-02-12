"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.deactivate = exports.activate = void 0;
const vscode = require("vscode");
const path = require("path");
const node_1 = require("vscode-languageclient/node");
//客户端  
let client;
//自动补全提供器  
let completionProvider;
//当前文本  
let currentGizDocument;
//高亮   
// 类名  
const classNameDecoration = vscode.window.createTextEditorDecorationType({
    color: 'rgba(40, 140, 140, 0.9)'
});
// 变量名  
const variableAndMemberDecoration = vscode.window.createTextEditorDecorationType({
    color: 'rgba(180, 180, 180, 0.9)'
});
// 字面量
const literalDecoration = vscode.window.createTextEditorDecorationType({
    color: 'rgba(255, 255, 100, 0.5)',
    backgroundColor: 'rgba(0, 0, 0, 0.1)'
});
// 命名空间黑
const namespaceDecoration = vscode.window.createTextEditorDecorationType({
    color: 'rgba(100, 100, 100, 0.9)'
});
//状态  
let updateHightlightCallback;
let updateCompletionCallback;
let timerUpdateHightlight = -1;
let timerUpdateCompletion = -1;
//控制台  
let output = vscode.window.createOutputChannel("Gizbox");
//激活扩展  
function activate(context) {
    // 确保路径正确
    const serverModule = context.asAbsolutePath(path.join('bin', 'GizboxLSP.dll'));
    const serverOptions = {
        run: { command: 'dotnet', args: [serverModule] },
        debug: { command: 'dotnet', args: [serverModule] }
    };
    const clientOptions = {
        documentSelector: [{ scheme: 'file', language: 'text/plain' }],
        synchronize: {
            fileEvents: vscode.workspace.createFileSystemWatcher('**/.gix')
        },
        outputChannelName: 'GizboxLang Server',
        traceOutputChannel: vscode.window.createOutputChannel('GizboxLang Server Trace'),
        initializationOptions: {
        //...其他信息    
        }
    };
    client = new node_1.LanguageClient('langServer', 'GizboxLang Server', serverOptions, clientOptions);
    //活动的编辑器文本打开事件
    //vscode.workspace.onDidOpenTextDocument
    vscode.window.onDidChangeActiveTextEditor((teditor) => {
        const isGizbox = vscode.window.activeTextEditor?.document.languageId === 'gizbox';
        if (isGizbox) {
            // vscode.window.showInformationMessage("进入新的Giz文档");
            //高亮刷新  
            setTimeout(() => {
                if (vscode.window.activeTextEditor?.document != null) {
                    const params = {
                        textDocument: { uri: vscode.window.activeTextEditor?.document.uri.toString() },
                        position: { line: 0, character: 0 }
                    };
                    client.sendRequest('textDocument/documentHighlight', params).then((highlights) => {
                        const editor = vscode.window.activeTextEditor;
                        ApplyHighlights(editor, highlights);
                        // vscode.window.showInformationMessage(JSON.stringify(highlights));
                    }, error => {
                        vscode.window.showInformationMessage(error);
                    });
                }
            }, 500);
        }
    });
    //客户端启动  
    var promise = client.start();
    //Start  
    ClientStart();
    //开始Update  
    const deltatime = 100;
    setInterval(() => {
        ClientUpdate(deltatime);
    }, deltatime);
    //文本改变事件监听  
    vscode.workspace.onDidChangeTextDocument(event => {
        const contentChanges = event.contentChanges;
        const document = event.document;
        const isGizbox = document.languageId === 'gizbox';
        if (isGizbox === false)
            return;
        if (contentChanges.length > 0) {
            vscode.window.showInformationMessage("****contentChanges***\ncount:" + contentChanges.length);
            //增量同步 
            const params = {
                textDocument: { uri: event.document.uri.toString() },
                contentChanges: contentChanges.map(change => ({
                    range: {
                        start: { line: change.range.start.line, character: change.range.start.character },
                        end: { line: change.range.end.line, character: change.range.end.character }
                    },
                    rangeLength: change.rangeLength,
                    text: change.text,
                    debug: "didChange: start line:" + change.range.start.line
                }))
            };
            client.sendNotification('textDocument/didChange', params);
            output.appendLine("增量更新");
            // output.appendLine("send didChangeParam:\n\n" + JSON.stringify(params));
            const lastChange = contentChanges[contentChanges.length - 1];
            //update中  请求Highlight   
            {
                if (timerUpdateHightlight < 0.0) {
                    updateHightlightCallback = (() => {
                        const position = lastChange.range.end;
                        SendHighlightRequest(document, position);
                    });
                }
                timerUpdateHightlight = 500;
            }
            //update中  请求Completion   
            {
                if (timerUpdateCompletion < 0.0) {
                    updateCompletionCallback = (() => {
                        {
                            const position = lastChange.range.start;
                            const params = {
                                textDocument: { uri: document.uri.toString() },
                                position: { line: position.line, character: position.character + 1 }
                            };
                            client.sendRequest('textDocument/completion', params).then((completionItems) => {
                                UpdateCompletionProvider(context, completionItems);
                                //立刻显示全部补全项（不等待输入首字母或者模糊字母才显示）    
                                if (lastChange.text.endsWith('.')) {
                                    vscode.commands.executeCommand('editor.action.triggerSuggest');
                                }
                            });
                        }
                    });
                }
                timerUpdateCompletion = 500;
            }
            // // 如果输入分割字符  补全  
            // const text = contentChanges[0].text;
            // const rangeLength = contentChanges[0].rangeLength;
            // if (rangeLength > 0 || text.endsWith('.')|| text.endsWith(';') || text.endsWith(':') || text.endsWith(' ') || text.endsWith('\n') || /\s/.test(text)) {
            // }
        }
    });
}
exports.activate = activate;
function ClientStart() {
    output.appendLine("Client Start");
    //截获Log  
    client.onNotification("debug/log", (params) => {
        output.appendLine("server log >>> " + params.text);
    });
    //启动...秒后刷新高亮  
    setTimeout(() => {
        TrySetCurrentGizTextDocument();
        if (currentGizDocument != null) {
            SendHighlightRequest(currentGizDocument, { line: 0, character: 0 });
        }
    }, 2000);
    output.appendLine("hightlight刷新");
    //初始全量更新一次   
    setTimeout(() => {
        output.appendLine("初始全量更新...");
        FullContentUpdate();
        output.appendLine("初始全量更新完成...");
    }, 3000);
    //每10秒全量更新  
    setInterval(() => {
        TrySetCurrentGizTextDocument();
        if (currentGizDocument != null) {
            FullContentUpdate();
        }
    }, 10000);
}
//Update  
function ClientUpdate(deltatime) {
    if (timerUpdateHightlight > 0) {
        timerUpdateHightlight -= deltatime;
        if (timerUpdateHightlight <= 0) {
            updateHightlightCallback();
            timerUpdateHightlight = -1;
        }
    }
    if (timerUpdateCompletion > 0) {
        timerUpdateCompletion -= deltatime;
        if (timerUpdateCompletion <= 0) {
            updateCompletionCallback();
            timerUpdateCompletion = -1;
        }
    }
}
//设置当前文档  
function TrySetCurrentGizTextDocument() {
    const editor = vscode.window.activeTextEditor;
    if (editor?.document.languageId === "gizbox") {
        currentGizDocument = editor.document;
    }
}
//全量更新  
function FullContentUpdate() {
    output.appendLine("计时全量更新");
    const params = {
        textDocument: {
            uri: currentGizDocument.uri.toString()
        },
        contentChanges: [
            {
                text: currentGizDocument.getText(),
            }
        ]
    };
    client.sendNotification('textDocument/didChange', params);
    // vscode.window.showInformationMessage("Full Update");
}
//Highlight请求  
function SendHighlightRequest(document, position) {
    const params = {
        textDocument: { uri: document.uri.toString() },
        position: { line: position.line, character: position.character + 1 }
    };
    client.sendRequest('textDocument/documentHighlight', params).then((highlights) => {
        const editor = vscode.window.activeTextEditor;
        ApplyHighlights(editor, highlights);
    }, error => {
        vscode.window.showInformationMessage(error);
    });
}
//应用Highlight  
function ApplyHighlights(editor, highlights) {
    if (Array.isArray(highlights) && highlights.length > 0) {
        output.appendLine("---Apply Highlights  length:" + highlights.length);
        const classNameDecorationOpts = [];
        const variableDecorationOpts = [];
        const literalDecorationOpts = [];
        const namespaceDecorationOpts = [];
        // vscode.window.showInformationMessage("apply count:" + highlights.length);
        let count = 1;
        highlights.forEach(highlight => {
            count++;
            const range = new vscode.Range(new vscode.Position(highlight.range.start.line - 1, highlight.range.start.character), //行数从0开始的，而gizbox是从1开始！  
            new vscode.Position(highlight.range.end.line - 1, highlight.range.end.character));
            const decoration = { range: range };
            switch (highlight.kind) {
                case 1: // Class
                    classNameDecorationOpts.push(decoration);
                    break;
                case 2: // Member
                    variableDecorationOpts.push(decoration);
                    break;
                case 3: // Lit  
                    literalDecorationOpts.push(decoration);
                    break;
                case 4: // Namespace  
                    namespaceDecorationOpts.push(decoration);
                    break;
                default:
                    // 默认使用文本高亮
                    namespaceDecorationOpts.push(decoration);
                    break;
            }
        });
        // 应用不同的装饰
        editor.setDecorations(classNameDecoration, classNameDecorationOpts);
        editor.setDecorations(variableAndMemberDecoration, variableDecorationOpts);
        editor.setDecorations(literalDecoration, literalDecorationOpts);
        editor.setDecorations(namespaceDecoration, namespaceDecorationOpts);
    }
}
//补全提供器更新  
function UpdateCompletionProvider(context, completionItems) {
    // 将响应中的补全项转换为 VS Code 的 CompletionItem 格式
    const completionList = completionItems.items.map((item) => {
        // return new vscode.CompletionItem(item.label, vscode.CompletionItemKind.Text);
        let vsitm = new vscode.CompletionItem(item.label, item.kind);
        vsitm.detail = item.detail;
        vsitm.documentation = item.documentation;
        vsitm.insertText = item.insertText;
        return vsitm;
    });
    output.appendLine("---Apply Completion  length:" + completionList.length);
    // 如果已经存在补全提供者，则清理它
    if (completionProvider) {
        completionProvider.dispose();
    }
    // 创建新的补全提供者
    const provider = {
        provideCompletionItems: () => completionList
    };
    // 注册新的补全提供者，并添加到 context.subscriptions 中
    completionProvider = vscode.languages.registerCompletionItemProvider('gizbox', provider);
    context.subscriptions.push(completionProvider);
}
//终止  
function deactivate() {
    if (!client) {
        return undefined;
    }
    return client.stop();
}
exports.deactivate = deactivate;
//# sourceMappingURL=client.js.map