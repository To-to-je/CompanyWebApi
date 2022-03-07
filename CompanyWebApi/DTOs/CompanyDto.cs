namespace CompanyWebApi.DTOs
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
