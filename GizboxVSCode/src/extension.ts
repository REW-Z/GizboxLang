import * as vscode from 'vscode';

import { activate as activateClient, deactivate as deactivateClient } from './client';

export function activate(context: vscode.ExtensionContext) {
    activateClient(context);
}

export function deactivate(): Thenable<void> | undefined {
    return deactivateClient();
}
