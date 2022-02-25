namespace CompanyWebApi.Core.Domain;

public class Product
{
    public string? Name { get; set; }
    public int ProductCode { get; set; }
    public virtual IEnumerable<Order>? Orders { get; set; }

}