using System.Text;
public static class Identifier
{
    public static string Clean(string identifier)
    {        
        StringBuilder  sb = new StringBuilder();
        bool toUpper = false;
        
        foreach(char c in identifier){
            if(char.IsWhiteSpace(c)){
                sb.Append('_');
            }
            else if(char.IsControl(c)){
                sb.Append("CTRL");
            }
            else if(c == '-'){
                toUpper = true;
            }
            else if(c >= 'α' && c <= 'ω'){
                continue;
            }
            else if(char.IsLetter(c)){    
                char cleanChar = char.ToLower(c);
                sb.Append(toUpper ? char.ToUpper(cleanChar) : c);
                toUpper = false;
            }                     
        }
        return sb.ToString();
    }
}
