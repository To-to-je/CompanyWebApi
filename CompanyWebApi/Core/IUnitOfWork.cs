using CompanyWebApi.Core.Repositories;

namespace CompanyWebApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Company { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        IAppointmentRepository Appointment { get; }
        IGroupTypeRepository GroupType { get; }

        Task Complete();
    }
}
