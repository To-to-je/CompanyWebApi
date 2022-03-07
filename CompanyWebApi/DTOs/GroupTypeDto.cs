using CompanyWebApi.DBOs.MappingProfiles;

namespace CompanyWebApi.DBOs
{
    public class GroupTypeDto : BaseDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }
    }
}
