using CompanyWebApi.Core.Domain;

namespace CompanyWebApi.Core.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IQueryable<Company>> GetMostFrequentVisitors(int topNumber);
        Task<IQueryable<string?>?> GetAllVisitorsForDateRange(DateRange range);

    }
}
