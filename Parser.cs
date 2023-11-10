using SHRK_LEXER;
using SHRK_UTILS;

namespace SHRK_PARSER{
    public static class Parser{
        public static Dictionary<string, dynamic> vals = new Dictionary<string, dynamic>();
        public static Dictionary<string, string> funcs = new Dictionary<string, string>();
        public static Dictionary<string, string> argums = new Dictionary<string, string>();
        public static void Pars(List<Token> tokens, Dictionary<string, string>? func){
            if (func!=null){foreach(var key in func.Keys){if(argums.ContainsKey(key)){argums[key] = func[key];}}}
            for (int i = 0; i < tokens.Count; i++){
                if (tokens[i].token=="лог"){ // лог "привет" | лог переменная
                    if (tokens[i+=1].type == Token.TokenType.TOKEN_TYPE_KOVICKI && tokens.Last().type == Token.TokenType.TOKEN_TYPE_KOVICKI){
                        Console.WriteLine(StringSetup.InKavichki(tokens));
                        i += tokens.Count();
                    }
                    else if (vals.TryGetValue(tokens[i].token, out var value)){
                        Console.WriteLine(value);
                    }
                    else{
                        Error.arg_error(tokens, tokens[i-=1]).ShowError();
                    }
                }
                else if (tokens[i].token=="если"){ //если(переменная=привет){лог пока}
                    String[] args = StringSetup.InScobki(tokens).Split('=');
                    i += tokens.Count();
                    if (vals.TryGetValue(args[0], out var value)){
                        if (value==args[1]){
                            String dothis = StringSetup.InFigurScobki(tokens);
                            Lexer iffer = new Lexer(StringSetup.StrSetup_(dothis), true, null);
                        }
                    }
                }
                else if (tokens[i].token=="функ"){ //функ дарова(фигня){лог "дарова ": лог фигня}
                    funcs.Add(tokens[i+=1].token, StringSetup.InFigurScobki(tokens));
                    i+=tokens.Count();
                }
                else{
                    if (tokens.Count()>=3){
                        if (funcs.TryGetValue(tokens[i].token, out var value)){
                            Lexer lex = new Lexer(StringSetup.StrSetup_(value), true, null);
                        }
                        else{
                            if (tokens.Last().token!="гет"){vals.Add(tokens.First().token, tokens.Last().token);}
                            else {vals.Add(tokens.First().token, Console.ReadLine() ?? "нуль");}
                            i += tokens.Count();
                        }
                    }
                }
            }
        }
    }
}