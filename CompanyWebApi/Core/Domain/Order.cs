namespace CompanyWebApi.Core.Domain;

public class Order
{
    public int OrderId { get; set; }
    public int CompanyId { get; set; }
    public virtual Product? Product { get; set; }
    public int ProductId { get; set; }
    public virtual Company? Company { get; set; }
    public DateTime DateOfOrder { get; set; }
    public DateTime? DateWhenContractWillExpire { get; set; }
    public DateTime DateOfCompanyProductionStateInitialization { get; set; }

    
}