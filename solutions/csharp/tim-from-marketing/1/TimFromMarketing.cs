static class Badge
{
    public static string Print(int? id, string name, string? department)
    {   
        string idSeccion = id.HasValue ? $"[{id}] - " : "";
        string departmentSection = string.IsNullOrWhiteSpace(department) ? "OWNER" : department.ToUpper();
        
        return $"{idSeccion}{name} - {departmentSection}";
    }
}
