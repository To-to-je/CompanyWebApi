using CompanyWebApi.DTOs;

namespace CompanyWebApi.DTOs
{
    public class ProductDto : BaseDto
    {
        public string? Name { get; set; }
        public int ProductCode { get; set; }
    }
}
