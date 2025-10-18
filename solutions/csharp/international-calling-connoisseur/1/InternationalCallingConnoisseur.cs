public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
        => new Dictionary<int, string>();

    public static Dictionary<int, string> GetExistingDictionary()
    {
        Dictionary<int, string> dictionary = GetEmptyDictionary();
        dictionary[1] = "United States of America";
        dictionary[55] = "Brazil";
        dictionary[91] = "India";
        return dictionary;
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        Dictionary<int, string> dictionary = GetEmptyDictionary();
        dictionary.Add(countryCode, countryName);
        return dictionary;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if(CheckCodeExists(existingDictionary, countryCode))
            return existingDictionary[countryCode];
        return string.Empty;
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
        => existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if(CheckCodeExists(existingDictionary, countryCode)){
            existingDictionary[countryCode] = countryName;            
        }
        return existingDictionary;            
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if(CheckCodeExists(existingDictionary, countryCode)){
            existingDictionary.Remove(countryCode);            
        }
         return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        if(existingDictionary == null || existingDictionary.Count == 0)
            return "";

        string longest = "";

        foreach(var country in existingDictionary)
        {
            if(country.Value.Length > longest.Length)
                longest = country.Value;
        }
        return longest;
    }
}