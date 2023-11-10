using SHRK_LEXER;
using SHRK_UTILS;

public class Programm {
    public static void Main(string[] args){
        String code = "вар = гет; если(вар=hello){лог \"дрова порубили\":};";
        Lexer l = new Lexer(StringSetup.StrSetup(code), false, null);
    }
}