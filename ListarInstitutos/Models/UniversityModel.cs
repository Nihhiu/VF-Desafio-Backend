namespace Model.University;

public class UniversityClass{
    public string? AlphaTwoCode { get; set; }
    public List<string>? Domains { get; set; }
    public string? Country { get; set; } 
    public string? StateProvince { get; set; }
    public List<string>? Web_pages { get; set; }
    public required string Name { get; set; }
}