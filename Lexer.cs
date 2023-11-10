using System.Security.Cryptography.X509Certificates;
using SHRK_PARSER;
using SHRK_UTILS;

namespace SHRK_LEXER{
    public class Token{
        public enum TokenType{
            TOKEN_TYPE_KOVICKI,
            TOKEN_TYPE_TOCKASSAPIATOY,
            TOKEN_TYPE_OPEN_SCKOBKA,
            TOKEN_TYPE_CLOSE_SCKOBKA,
            TOKEN_TYPE_OPEN_FIGUR_SCKOBKA,
            TOKEN_TYPE_CLOSE_FIGUR_SCKOBKA,
            TOKEN_TYPE_NAME
        }
        public TokenType type;
        public int line = 0;
        public string token;
        public Token(TokenType type, string token, int line){
            this.type = type;
            this.token = token;
            this.line = line;
        }
    }
    public class Lexer{
        static int line = 0;
        public static List<Token> Lex(List<string> command){
            List<Token> tokens = new List<Token>();
            for (int i = 0; i < command.Count; i++){
                string cmd = command[i];
                switch (cmd){
                    case "(": tokens.Add(new Token(Token.TokenType.TOKEN_TYPE_OPEN_SCKOBKA, cmd, line)); break;
                    case ")": tokens.Add(new Token(Token.TokenType.TOKEN_TYPE_CLOSE_SCKOBKA, cmd, line)); break;
                    case "{": tokens.Add(new Token(Token.TokenType.TOKEN_TYPE_OPEN_FIGUR_SCKOBKA, cmd, line)); break;
                    case "}": tokens.Add(new Token(Token.TokenType.TOKEN_TYPE_CLOSE_FIGUR_SCKOBKA, cmd, line)); break;
                    case "\"": tokens.Add(new Token(Token.TokenType.TOKEN_TYPE_KOVICKI, cmd, line)); break;
                    case "\n": line++; break;
                    default: tokens.Add(new Token(Token.TokenType.TOKEN_TYPE_NAME, cmd, line)); break;
                }
            }
            return tokens;
        }

        public Lexer(List<string> code, bool func_, string? func){
            List<string> list = new List<string>();
            for (int i = 0; i < code.Count; i++) {
                if (code[i] ==";"){Parser.Pars(Lex(list), null); list.Clear();}
                else if(func_ && code[i]==":"){Parser.Pars(Lex(list), null); list.Clear();}
                else { list.Add(code[i]); }
            }
        }
    }
}