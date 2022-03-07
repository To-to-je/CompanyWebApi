using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.Core.Repositories;
using CompanyWebApi.DBOs;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {

        public CompanyContext? CompanyContext => Context as CompanyContext;


        public AppointmentRepository(DbContext context) : base(context)
        {
        }



        public async Task<IQueryable<Company>> GetMostFrequentVisitors(int topNumber)
        {
            if (CompanyContext?.Companies != null && CompanyContext.Appointments != null)

            {
                var topCompaniesId = await CompanyContext.Appointments
                .GroupBy(a => a.CompanyId)
                .Select(group => new
                {
                    CompanyId = group.Key,
                    NumberOfAppointments = group.Count()
                })
                .OrderByDescending(c => c.NumberOfAppointments)
                .Take(topNumber)
                .Select(c => c.CompanyId)
                .ToListAsync();
                    


                 return CompanyContext.Companies
                    .Where(c => topCompaniesId.Contains(c.Id))
                    .Select(c => c);

                

            }
            else
            {
                throw new NullReferenceException("No companies or appointments in DataBase");
            }


        }
        public async Task<IQueryable<string?>?> GetAllVisitorsForDateRange(DateRange range)
        {
            if (CompanyContext?.Appointments != null && CompanyContext?.Companies != null)
            {
                var companiesIdList = await CompanyContext?.Appointments
                    .Where(a => a.AppointmentDate <= range.End && a.AppointmentDate >= range.Start)
                    .Select(a => a.CompanyId)
                    .ToListAsync()!;

                return CompanyContext?.Companies
                    .Where(c => companiesIdList.Contains(c.Id))
                    .Select(c => c.Name);

            }
            else
            {
                throw new NullReferenceException("No companies or appointments in database");
            }
        }

    }
}
