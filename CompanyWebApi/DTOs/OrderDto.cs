using CompanyWebApi.DTOs;

namespace CompanyWebApi.DTOs
{
    public class OrderDto : BaseDto
    {
        public int OrderId { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public DateTime? DateWhenContractWillExpire { get; set; }
        public DateTime DateOfCompanyProductionStateInitialization { get; set; }

    }
}
