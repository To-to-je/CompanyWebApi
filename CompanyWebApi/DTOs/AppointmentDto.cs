using CompanyWebApi.DTOs;

namespace CompanyWebApi.DTOs
{
    public class AppointmentDto : BaseDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int CompanyId { get; set; }
    }
}
