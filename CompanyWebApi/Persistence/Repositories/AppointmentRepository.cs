using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {

        public CompanyContext? CompanyContext => Context as CompanyContext;


        public AppointmentRepository(DbContext context) : base(context)
        {
        }



        public async Task<IEnumerable<Company>> GetMostFrequentVisitors(int topNumber)
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



                return await CompanyContext.Companies
                    .Where(c => topCompaniesId.Contains(c.Id))
                    .Select(c => c)
                    .ToListAsync();

            }
            else
            {
                throw new NullReferenceException("No companies or appointments in DataBase");
            }


        }
        public async Task<IEnumerable<string?>?> GetAllVisitorsForDateRange(DateRange range)
        {
            if (CompanyContext?.Appointments != null && CompanyContext?.Companies != null)
            {
                var companiesIdList = await CompanyContext?.Appointments
                    .Where(a => a.AppointmentDate <= range.End && a.AppointmentDate >= range.Start)
                    .Select(a => a.CompanyId)
                    .ToListAsync()!;

                return await CompanyContext?.Companies
                    .Where(c => companiesIdList.Contains(c.Id))
                    .Select(c => c.Name)
                    .ToListAsync()!;

            }
            else
            {
                throw new NullReferenceException("No companies or appointments in database");
            }
        }

        public async Task Change(Appointment appointment)
        {
            if (CompanyContext?.Appointments != null)
            {
                var appointmentInDatabase = await CompanyContext?.Appointments.FirstOrDefaultAsync(c => c.Id == appointment.Id)!;

                if (appointmentInDatabase != null)
                {
                    appointmentInDatabase.AppointmentDate = appointment.AppointmentDate;
                    appointmentInDatabase.CompanyId = appointment.CompanyId;
                    appointmentInDatabase.EmployeeName = appointment.EmployeeName;
                    appointmentInDatabase.Title = appointment.Title;
                }
                else
                {
                    throw new NullReferenceException();
                }

            }
        }
    }
}
