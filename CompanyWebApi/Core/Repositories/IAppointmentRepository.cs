using CompanyWebApi.Core.Domain;

namespace CompanyWebApi.Core.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Company>> GetMostFrequentVisitors(int topNumber);
        Task<IEnumerable<string?>?> GetAllVisitorsForDateRange(DateRange range);
        Task Change(Appointment appointment);

    }
}
