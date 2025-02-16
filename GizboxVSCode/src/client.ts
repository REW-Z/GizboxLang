
import * as vscode from 'vscode';
import * as path from 'path';
import { DidChangeWorkspaceFoldersNotification, LanguageClientOptions, SynchronizeOptions, WorkspaceFolder} from 'vscode-languageclient';
import { LanguageClient, ServerOptions, TransportKind} from 'vscode-languageclient/node';
import { channel } from 'diagnostics_channel';
import { json, text } from 'stream/consumers';
import { start } from 'repl';
import { stringify } from 'querystring';
import { log } from 'console';


//客户端  
let client: LanguageClient;
let clientRunning : boolean = false;

//自动补全提供器  
let completionProvider: vscode.Disposable | undefined;

//当前文本编辑器    
let currentTextEditor : vscode.TextEditor | undefined;

//Timeout相关  
let fullContentUpdateByIntervalTimeout : NodeJS.Timeout | undefined = undefined;

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

//状态  
let updateHightlightCallback : () => void;
let updateCompletionCallback : () => void;
let timerUpdateHightlight : number = -1;
let timerUpdateCompletion : number = -1;

//控制台  
let output : vscode.OutputChannel = vscode.window.createOutputChannel("Gizbox");


//激活扩展  
export function activate(context: vscode.ExtensionContext) {

    output.appendLine("*** gizbox extension activate ***" + (new Date()).toLocaleString());

    //启动client
    //（REW: 貌似只有第一次进入gix文档会调用该函数来激活扩展）     
    {
        //设置当前文档  
        currentTextEditor = vscode.window.activeTextEditor;
        //同步新文档
        const isGizbox = vscode.window.activeTextEditor?.document.languageId === 'gizbox';
        if(isGizbox){
            ClientStart(context);
            StartSyncDocument(currentTextEditor);
        }
        else{ throw "错误的扩展激活？？"; }
    }



    //所有Visible编辑器改变事件  
    //（REW:output窗口也是文件编辑器）  
    //（REW:切换或打开文本标签页会触发，触发时activeTextEditor已更新）    
    vscode.window.onDidChangeVisibleTextEditors((veditors : readonly vscode.TextEditor[]) => {
        output.appendLine("VisibleTextEditors Changed:" + veditors.map(e => e?.document.fileName + ", ") + "  语言类型" + veditors.map(e => e?.document.languageId + ", "));
        output.appendLine("Current LanguageID" + vscode.window.activeTextEditor?.document.languageId);
        OnChangeDocument(context);
    });

    //文本改变事件监听  
    vscode.workspace.onDidChangeTextDocument(event => {

        const contentChanges = event.contentChanges;
        const document = event.document;

        if (document.languageId != 'gizbox') return;

        if (currentTextEditor?.document != event.document) return;

        if (contentChanges.length > 0) 
        {
            //增量同步 
            Request_IncrementalContentUpdate(currentTextEditor, contentChanges);
            
            //update中  请求Highlight   
            const lastChange = contentChanges[contentChanges.length - 1];
            if(currentTextEditor?.document === event.document)
            {
                if (timerUpdateHightlight < 0.0) {
                    updateHightlightCallback = (() => {
                        const position = lastChange.range.end;
                        Request_Highlight(currentTextEditor, position);
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
                            
                            client.sendRequest('textDocument/completion', params).then((completionItems: any) => {
                                ApplyCompletionToProvider(context, completionItems);
        
                                //立刻显示全部补全项（不等待输入首字母或者模糊字母才显示）    
                                if(lastChange.text.endsWith('.'))
                                {
                                    vscode.commands.executeCommand('editor.action.triggerSuggest');
                                }
                            });
                        } 
                    });
                }
                timerUpdateCompletion = 500;
            }
        }
    });


    //Active文本编辑器改变事件（聚焦事件）  
    // （REW：聚焦会触发一次 ->neweditor)（聚焦output等窗口也会发生改变，所以不怎么适用）  
    // （REW：打开窗口触发两次 ->undefine->neweditor）  
    // vscode.window.onDidChangeActiveTextEditor((teditor : any) => {
    //     output.appendLine("聚焦:" + vscode.window.activeTextEditor?.document.fileName);
    // });
    
    // //notebook是指".ipynb"等文件类型的编辑器    
    // vscode.window.onDidChangeActiveNotebookEditor((neditor: any) => {
    // });

}

function OnChangeDocument(context : vscode.ExtensionContext) : void
{
    if(vscode.window.activeTextEditor == currentTextEditor) return;

    //设置CurrentTextEditor    
    let prevTextEditor = currentTextEditor;
    currentTextEditor = vscode.window.activeTextEditor;
    
    //启动或者终止客户端  
    let anyGizboxDocument = false;
    let currIsGizbox = currentTextEditor?.document.languageId === 'gizbox';
    for(let i = 0; i < vscode.window.visibleTextEditors.length; ++i)
    {
        if(vscode.window.visibleTextEditors[i]?.document.languageId === 'gizbox')
        {
            anyGizboxDocument = true;
            break;
        }
    }
    if(anyGizboxDocument === true && clientRunning === false)
    {
        output.appendLine("启动Client");
        ClientStart(context);
        output.appendLine("启动Client完毕...");
    }
    else if(anyGizboxDocument === false && clientRunning === true)
    {
        ClientEnd();
    }

    //重新同步文档(新的gix文档时)    
    if(prevTextEditor != currentTextEditor && currIsGizbox)
    {
        output.appendLine("同步gix文档中...");
        //开始同步文档  
        StartSyncDocument(currentTextEditor);
        output.appendLine("同步文档完毕...");
    }
}

function StartSyncDocument(teditor:vscode.TextEditor | undefined) : void
{
    if(teditor === undefined) return;
    
    clearInterval(fullContentUpdateByIntervalTimeout);


    //请求服务器打开文档  
    Request_OpenDoc(teditor);  

    //首次刷新高亮  
    Request_Highlight(teditor, {line:0, character:0});
    output.appendLine("初始全量更新...");


    //每10秒全量更新(同时刷新高亮)     
    fullContentUpdateByIntervalTimeout = setInterval(() => {
        if(teditor === currentTextEditor)
        {
            Request_FullContentUpdate(teditor);
            Request_Highlight(teditor, {line:0, character:0});
            output.appendLine("计时全量更新成功...");
        }
    }, 10000);
}


function ClientStart(context: vscode.ExtensionContext)
{
    if(clientRunning === true) return;

    // 确保路径正确
    const serverModule = context.asAbsolutePath(path.join('bin', 'GizboxLSP.dll'));

    //创建客户端  
    const serverOptions: ServerOptions = {
        run: { command: 'dotnet', args: [serverModule] },
        debug: { command: 'dotnet', args: [serverModule] }
    };
    const clientOptions: LanguageClientOptions = {
        documentSelector: [{ scheme: 'file', language: 'text/plain' }],
        synchronize: {
            fileEvents: vscode.workspace.createFileSystemWatcher('**/.gix')
        },
        outputChannelName: 'GizboxLang Server',
        traceOutputChannel: vscode.window.createOutputChannel('GizboxLang Server Trace'),
        initializationOptions:{
            //...其他信息    
        }
    };
    client = new LanguageClient(
        'langServer',
        'GizboxLang Server',
        serverOptions,
        clientOptions
    );

    //客户端启动  
    var promise = client.start();

    clientRunning = true;


    //截获Log  
    client.onNotification("debug/log", (params) => {
        output.appendLine("server log >>> " + params.text);
    });

    
    //开始Update  
    const deltatime = 100;
    setInterval(() => {
        ClientUpdate(deltatime);
    }, deltatime);

    


    output.appendLine("*** gizbox client started ***" + (new Date()).toLocaleString());
}

//Update  
function ClientUpdate(deltatime : number)
{
    if(timerUpdateHightlight > 0)
    {
        timerUpdateHightlight -= deltatime;

        if(timerUpdateHightlight <= 0)
        {
            updateHightlightCallback();
            timerUpdateHightlight = -1;
        }
    }

    if(timerUpdateCompletion > 0)
    {
        timerUpdateCompletion -= deltatime;
        if(timerUpdateCompletion <= 0)
        {
            updateCompletionCallback();
            timerUpdateCompletion = -1;
        }
    }
}

function ClientEnd(): Thenable<void> | undefined
{
    if (!client) {
        return undefined;
    }
    if(clientRunning === false){
        return undefined;
    }

    //关闭定时全量同步  
    clearInterval(fullContentUpdateByIntervalTimeout);

    //关闭客户端和服务器  
    let then = client.stop();
    clientRunning = false;
    client.dispose();

    
    output.appendLine("*** gizbox client end ***" + (new Date()).toLocaleString());
    return then;
}

function Request_OpenDoc(teditor : vscode.TextEditor | undefined)
{
    const params = {
        textDocument: 
        { 
            uri: teditor?.document?.uri.toString(),
            text: teditor?.document?.getText(),
        }
    };
    client.sendNotification('textDocument/didOpen', params);
}

//全量同步    
function Request_FullContentUpdate(teditor : vscode.TextEditor | undefined)
{
    const params = {
        textDocument: 
        { 
            uri: teditor?.document?.uri.toString()
        },
        contentChanges: [
            {
                text: teditor?.document?.getText(),
            }
        ] 
    };
    client.sendNotification('textDocument/didChange', params);
}

//增量同步 
function Request_IncrementalContentUpdate(teditor : vscode.TextEditor | undefined,  contentChanges : readonly vscode.TextDocumentContentChangeEvent[])
{
    const params = {
        textDocument: { uri: teditor?.document.uri.toString() },
        contentChanges: contentChanges.map(change => ({
            range: {
                start: { line: change.range.start.line, character: change.range.start.character },
                end: { line: change.range.end.line, character: change.range.end.character }
            },
            rangeLength: change.rangeLength,
            text: change.text,
            debug:"didChange: start line:" + change.range.start.line
        }))
    };
    client.sendNotification('textDocument/didChange', params);
}

//Highlight请求  
function Request_Highlight(teditor: vscode.TextEditor | undefined, position : any)
{
    const params = {
        textDocument: { uri: teditor?.document.uri.toString() },
        position: { line: position.line, character: position.character + 1 }
    };
    
    client.sendRequest('textDocument/documentHighlight', params).then((highlights) => {
        ApplyHighlights(teditor, highlights);

    }, error => {
        output.appendLine("request highlight err:" + error);
    });
}

//应用Highlight  
function ApplyHighlights(teditor: vscode.TextEditor | undefined, highlights: unknown) {
    if (Array.isArray(highlights) && highlights.length > 0)
    {
        output.appendLine("---Apply Highlights  length:" + highlights.length);
        const classNameDecorationOpts: vscode.DecorationOptions[] = [];
        const variableDecorationOpts: vscode.DecorationOptions[] = [];
        const literalDecorationOpts: vscode.DecorationOptions[] = [];
        const namespaceDecorationOpts: vscode.DecorationOptions[] = [];



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
        teditor?.setDecorations(classNameDecoration, classNameDecorationOpts);
        teditor?.setDecorations(variableAndMemberDecoration, variableDecorationOpts);
        teditor?.setDecorations(literalDecoration, literalDecorationOpts);
        teditor?.setDecorations(namespaceDecoration, namespaceDecorationOpts);
    }
}

//补全提供器更新  
function ApplyCompletionToProvider(context: vscode.ExtensionContext, completionItems: any) {

    // 将响应中的补全项转换为 VS Code 的 CompletionItem 格式
    const completionList = completionItems.items.map((item: any) => {
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
export function deactivate(): Thenable<void> | undefined 
{
    output.appendLine("*** gizbox extension deactivate ***" + (new Date()).toLocaleString());

    return ClientEnd();
}


//1. 有缩进时无法找到标识符
//2. 服务器有时会自动中止  