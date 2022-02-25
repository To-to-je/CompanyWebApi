namespace CompanyWebApi.Core.Domain
{
    public class Appointment
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }

}
