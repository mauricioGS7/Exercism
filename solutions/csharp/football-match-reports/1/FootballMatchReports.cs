using System.Reflection;
public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        string? player = null;
        switch(shirtNum){
            case 1:
                player = "goalie";
                break;
            case 2:
                player = "left back";
                break;
            case 3:
            case 4:
                player = "center back";
                break;
            case 5:
                player = "right back";
                break;
            case 6:
            case 7:
            case 8:
                player = "midfielder";
                break;
            case 9:
                player = "left wing";
                break;
            case 10:
                player = "striker";
                break;
            case 11:
                player = "right wing";
                break;
            default:
                player = "UNKNOWN";
                break;                
        }
        return player;
    }
   
    public static string AnalyzeOffField(object report)
{
    switch (report)
    {
        case int supporters:
            return $"There are {supporters} supporters at the match.";

        case string announcement:
            return announcement;

        case Foul:
            return "The referee deemed a foul.";

        case Injury injury:            
            var field = injury.GetType().GetField("player", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
            {
                var playerValue = field.GetValue(injury);
                return $"Oh no! Player {playerValue} is injured. Medics are on the field.";
            }           
            return "Oh no! Player is injured. Medics are on the field.";

        case Incident:
            return "An incident happened.";

        case Manager manager:
            return manager.Club == null ? manager.Name : $"{manager.Name} ({manager.Club})";

        default:
            return string.Empty;
    }
}
}
