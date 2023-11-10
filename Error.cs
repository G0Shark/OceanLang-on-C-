using System.Drawing;
using System.Security.Principal;
using SHRK_LEXER;

public class Error{
    public enum ErrorType{
        ERROR_TYPE_SYNTAX
    }
    public readonly ErrorType type;
    public readonly string ErrorCode;
    public readonly List<Token> cmd;
    public readonly Token Error_token;
    public Error(ErrorType type, List<Token> cmd, Token Error_token, string? ErrorCode){
        this.cmd = cmd;
        this.Error_token = Error_token;
        this.type = type;
        this.ErrorCode = ErrorCode != null ? ErrorCode : "Unknown error";
    }
    public void ShowError(){
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ErrorCode);
        Thread.Sleep(5000);
        Console.ResetColor();
        Console.Clear();
    }
    public static Error arg_error(List<Token> cmd, Token token) {
        string cmd_string = "";
        string error_string = "";
        foreach (Token tok in cmd) {
            cmd_string += tok.token + ' ';
            if (tok!=token) { error_string = error_string.PadLeft(tok.token.Length); }
            else { error_string = error_string.PadLeft(tok.token.Length/2) + "^" + error_string.PadRight(tok.token.Length/2); }
        }
        return new Error(ErrorType.ERROR_TYPE_SYNTAX, cmd, token, "Отсутствует аргумент для " + token.token + " | Строка: " + token.line + "\n" + cmd_string + "\n" + error_string);
    }
}