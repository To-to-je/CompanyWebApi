namespace CompanyWebApi.Core.Domain;

public class Order
{
    public int OrderId { get; set; }
    public int CompanyId { get; set; }
    public virtual IEnumerable<Product>? Products { get; set; }

    private int _numberOfProducts;

    public int NumberOfProducts
    {
        get => _numberOfProducts;
        private set
        {
            if (Products != null)
            {
                _numberOfProducts = Products.Count();
            }
            else
            {
                _numberOfProducts = 0;
            }
        }

    }
    public DateTime DateOfOrder { get; set; }
    public DateTime? DateWhenContractWillExpire { get; set; }
    public DateTime? DateOfCompanyProductionStateInitialization { get; set; }

    
}