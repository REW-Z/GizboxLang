
import * as vscode from 'vscode';
import * as path from 'path';
import { DidChangeWorkspaceFoldersNotification, LanguageClientOptions, SynchronizeOptions, WorkspaceFolder} from 'vscode-languageclient';
import { LanguageClient, ServerOptions, TransportKind} from 'vscode-languageclient/node';
import { channel } from 'diagnostics_channel';
import { json } from 'stream/consumers';
import { start } from 'repl';




//客户端  
let client: LanguageClient;

//自动补全提供器  
let completionProvider: vscode.Disposable | undefined;

//当前文本  
let currentGizDocument : vscode.TextDocument;


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
    backgroundColor : 'rgba(0, 0, 0, 0.1)'
});
// 命名空间黑
const namespaceDecoration = vscode.window.createTextEditorDecorationType({
    color: 'rgba(100, 100, 100, 0.9)'
});





//激活扩展  
export function activate(context: vscode.ExtensionContext) {

    // 确保路径正确
    const serverModule = context.asAbsolutePath(path.join('bin', 'GizboxLSP.dll'));

    const serverOptions: ServerOptions = {
        run: { command: 'dotnet', args: [serverModule] },
        debug: { command: 'dotnet', args: [serverModule] }
    };


    const clientOptions: LanguageClientOptions = {
        documentSelector: [{ scheme: 'file', language: 'plaintext' }],
        synchronize: {
            fileEvents: vscode.workspace.createFileSystemWatcher('**/.gix')
        },
        outputChannelName: 'Language Server Example',
        traceOutputChannel: vscode.window.createOutputChannel('Language Server Trace'),
        initializationOptions:{
            //...其他信息    
        }
    };

    client = new LanguageClient(
        'languageServerExample',
        'Language Server Example',
        serverOptions,
        clientOptions
    );


    

    //活动的编辑器文本打开事件
    //vscode.workspace.onDidOpenTextDocument
    vscode.window.onDidChangeActiveTextEditor((teditor : any) => {
        const isGizbox = vscode.window.activeTextEditor?.document.languageId === 'gizbox';
        if(isGizbox)
        {
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
                        applyHighlights(editor, highlights);

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

    //截获Log  
    client.onNotification("debug/log", (params) => {
        vscode.window.showInformationMessage("stream log:\n" + params.text);
    })


    //启动...秒后刷新高亮  
    setTimeout(() => {
        TrySetCurrentGizTextDocument();
        if(currentGizDocument != null){
            SendHighlightRequest(currentGizDocument, {line:0, character:0});
        }
    }, 2000);

    //每10秒全量更新  
    setInterval(() => {
        TrySetCurrentGizTextDocument();
        if(currentGizDocument != null)
        {
            FullContentUpdate();
        }  

    }, 10000);


    //文本改变事件监听  
    vscode.workspace.onDidChangeTextDocument(event => {

        const contentChanges = event.contentChanges;
        const document = event.document;
        const isGizbox = document.languageId === 'gizbox';

        if (isGizbox === false) return;

        if (contentChanges.length > 0) {
            
            // vscode.window.showInformationMessage("ChangeCount:" + contentChanges.length);

            // //手动同步文本(改为自动增量同步)    
            // const params = {
            //     textDocument: { uri: event.document.uri.toString() },
            //     contentChanges: contentChanges.map(change => ({
            //         range: {
            //             start: { line: change.range.start.line, character: change.range.start.character },
            //             end: { line: change.range.end.line, character: change.range.end.character }
            //         },
            //         rangeLength: change.rangeLength,
            //         text: change.text,
            //         debug:"didChange: start line:" + change.range.start.line
            //     }))
            // };
            
            // vscode.window.showInformationMessage("Changes:" + JSON.stringify(params.contentChanges));
            // client.sendNotification('textDocument/didChange', params);
                
            
            // 如果输入分割字符，则发送补全、高亮请求
            const text = contentChanges[0].text;
            const rangeLength = contentChanges[0].rangeLength;
            if (rangeLength > 0 || text.endsWith('.')|| text.endsWith(';') || text.endsWith(':') || text.endsWith(' ') || text.endsWith('\n') || /\s/.test(text)) {
                
                setTimeout(() => {
                    {
                        const position = contentChanges[0].range.start;
                        SendHighlightRequest(document, position);
                    }
                }, 100);

                setTimeout(() => {
                    {
                        const position = contentChanges[0].range.start;
                        const params = {
                            textDocument: { uri: document.uri.toString() },
                            position: { line: position.line, character: position.character + 1 }
                        };
                        
                        client.sendRequest('textDocument/completion', params).then((completionItems: any) => {
                            updateCompletionProvider(context, completionItems);

                            //REW：立刻显示全部补全项（不等待输入首字母或者模糊字母才显示）    
                            if(text.endsWith('.'))
                            {
                                vscode.commands.executeCommand('editor.action.triggerSuggest');
                            }
                        });

                        // vscode.window.showInformationMessage("Send: Completion");
                    }
                }, 200);

            }
        }
    });

}

function TrySetCurrentGizTextDocument()
{
    const editor = vscode.window.activeTextEditor;
    if(editor?.document.languageId === "gizbox")
    {
        currentGizDocument = editor.document;
    }
}

function FullContentUpdate()
{
    const params = {
        textDocument: 
        { 
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

function SendHighlightRequest(document: vscode.TextDocument, position : any)
{
    const params = {
        textDocument: { uri: document.uri.toString() },
        position: { line: position.line, character: position.character + 1 }
    };
    
    client.sendRequest('textDocument/documentHighlight', params).then((highlights) => {
        
        const editor = vscode.window.activeTextEditor;
        applyHighlights(editor, highlights);

    }, error => {
        vscode.window.showInformationMessage(error);
    });
}

function applyHighlights(editor: any, highlights: unknown) {
    if (Array.isArray(highlights) && highlights.length > 0)
    {
        const classNameDecorationOpts: vscode.DecorationOptions[] = [];
        const variableDecorationOpts: vscode.DecorationOptions[] = [];
        const literalDecorationOpts: vscode.DecorationOptions[] = [];
        const namespaceDecorationOpts: vscode.DecorationOptions[] = [];

        // vscode.window.showInformationMessage("apply count:" + highlights.length);

        let count : number = 1;
        highlights.forEach(highlight => {
            count ++;
            const range = new vscode.Range(
                new vscode.Position(highlight.range.start.line - 1, highlight.range.start.character),//行数从0开始的，而gizbox是从1开始！  
                new vscode.Position(highlight.range.end.line - 1, highlight.range.end.character)
            );

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
function updateCompletionProvider(context: vscode.ExtensionContext, completionItems: any) {

    // 将响应中的补全项转换为 VS Code 的 CompletionItem 格式
    const completionList = completionItems.items.map((item: any) => {
        return new vscode.CompletionItem(item.label, vscode.CompletionItemKind.Text);
    });

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
export function deactivate(): Thenable<void> | undefined {
    if (!client) {
        return undefined;
    }
    return client.stop();
}
