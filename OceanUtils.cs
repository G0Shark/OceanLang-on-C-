using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using SHRK_LEXER;
using static SHRK_LEXER.Token;
namespace SHRK_UTILS{
    public static class StringSetup{
        public static List<string> StrSetup(string code){
            char[] chars = code.ToCharArray();
            List<string> scode = new List<string>();
            string word = "";
            for (int i = 0; i < chars.Length; i++){
                switch (chars[i]){
                    case '\"': if(word!=""){scode.Add(word); word="";} scode.Add("\""); break;
                    case ';': if(word!=""){scode.Add(word); word="";} scode.Add(";"); break;
                    case '(': scode.Add(word); word=""; scode.Add("("); break;
                    case ')': scode.Add(word); word=""; scode.Add(")"); break;
                    case '{': scode.Add(word); word=""; scode.Add("{"); break;
                    case '}': scode.Add(word); word=""; scode.Add("}"); break;
                    case ' ': if(word!=""){scode.Add(word); word="";} break;
                    default: word += chars[i]; break;
                }
            }
            for(int i = 0; i < scode.Count()-1; i++){
                if (scode[i]==""){scode.RemoveAt(i);}
            }
            return scode;
        }
        public static List<string> StrSetup_(string code){
            char[] chars = code.ToCharArray();
            List<string> scode = new List<string>();
            string word = "";
            for (int i = 0; i < chars.Length; i++){
                switch (chars[i]){
                    case '\"': if(word!=""){scode.Add(word); word="";} scode.Add("\""); break;
                    case ':': if(word!=""){scode.Add(word); word="";} scode.Add(";"); break;
                    case '(': scode.Add(word); word=""; scode.Add("("); break;
                    case ')': scode.Add(word); word=""; scode.Add(")"); break;
                    case '{': scode.Add(word); word=""; scode.Add("{"); break;
                    case '}': scode.Add(word); word=""; scode.Add("}"); break;
                    case ' ': if(word!=""){scode.Add(word); word="";} break;
                    default: word += chars[i]; break;
                }
            }
            for(int i = 0; i < scode.Count()-1; i++){
                if (scode[i]==""){scode.RemoveAt(i);}
            }
            return scode;
        }
        public static string InKavichki(List<Token> tokens) {
            bool open = false;
            string ready = "";
            for (int i = 0; i < tokens.Count; i++) {
                if (tokens[i].type == TokenType.TOKEN_TYPE_KOVICKI){ open = !open; }
                else { if (open) { ready += tokens[i].token; } }
            }
            return ready;
        }
        public static string InScobki(List<Token> tokens) {
            bool open = false;
            string ready = "";
            for (int i = 0; i < tokens.Count; i++) {
                if (tokens[i].type == TokenType.TOKEN_TYPE_OPEN_SCKOBKA){ open = true; }
                else if (tokens[i].type == TokenType.TOKEN_TYPE_CLOSE_SCKOBKA){ open = false; }
                else { if (open) { ready += tokens[i].token;} }
            }
            return ready;
        }
        public static string InFigurScobki(List<Token> tokens) {
            bool open = false;
            string ready = "";
            for (int i = 0; i < tokens.Count; i++) {
                if (tokens[i].type == TokenType.TOKEN_TYPE_OPEN_FIGUR_SCKOBKA){ open = true; }
                else if (tokens[i].type == TokenType.TOKEN_TYPE_CLOSE_FIGUR_SCKOBKA){ open = false; }
                else { if (open) { ready += tokens[i].token; ready += " ";} }
            }
            return ready;
        }
    }
}