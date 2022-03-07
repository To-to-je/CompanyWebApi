using CompanyWebApi.DBOs.MappingProfiles;

namespace CompanyWebApi.DBOs
{
    public class CompanyDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupTypeId { get; set; }
        public DateTime CreationDate { get; }

        public DateTime? DateOfClientInitialization;

    }
}
