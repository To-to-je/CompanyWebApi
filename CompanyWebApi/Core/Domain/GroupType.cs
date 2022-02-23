namespace CompanyWebApi.Core.Domain;

public class GroupType
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public IList<Company>? Company { get; set; }
}