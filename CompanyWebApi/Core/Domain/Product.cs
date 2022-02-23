namespace CompanyWebApi.Core.Domain;

public class Product
{
    public string Name { get; set; }
    public int ProductCode { get; set; }

    public Product(string name, int productCode)
    {
        Name = name;
        ProductCode = productCode;
        
    }
}