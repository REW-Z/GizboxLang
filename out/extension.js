"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.deactivate = exports.activate = void 0;
const vscode = require("vscode");
const client_1 = require("./client");
function activate(context) {
    vscode.window.showInformationMessage('HelloWorld !');
    (0, client_1.activate)(context);
}
exports.activate = activate;
function deactivate() {
    return (0, client_1.deactivate)();
}
exports.deactivate = deactivate;
//# sourceMappingURL=extension.js.map