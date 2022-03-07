using CompanyWebApi.DBOs.MappingProfiles;

namespace CompanyWebApi.DBOs
{
    public class ProductDto : BaseDto
    {
        public string? Name { get; set; }
        public int ProductCode { get; set; }
    }
}
