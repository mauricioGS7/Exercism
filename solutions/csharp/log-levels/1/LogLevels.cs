static class LogLine
{
    public static string Message(string logLine)
    {        
        string[] logLineSplit = logLine.Split(": ", 2); 
        string logLineMessage = logLineSplit[1].Trim();
        return logLineSplit.Length >1 ? $"{logLineMessage}" : logLine.Trim();
    }

    public static string LogLevel(string logLine)
    {
        string[] logLineSplit = logLine.Split(": ", 2); 
        string logLevel = logLineSplit[0].Trim('[',']');
        return logLevel.ToLower();
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string logLevel = LogLevel(logLine);
        return $"{message} ({logLevel})";
    }
}
