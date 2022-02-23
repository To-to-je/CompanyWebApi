using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.Core.Repositories;
using CompanyWebApi.Persistence.Repositories;

namespace CompanyWebApi.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly CompanyContext _context;

        public UnitOfWork(CompanyContext context)
        {
            _context = context;
            Company = new CompanyRepository(context);
            Order = new OrderRepository(context);
            Product = new ProductRepository(context);
            Appointment = new AppointmentRepository(context);
            GroupType = new GroupTypeRepository(context);
        }


       

        public ICompanyRepository Company { get; }
        public IOrderRepository Order { get; }
        public IProductRepository Product { get; }
        public IAppointmentRepository Appointment { get; }
        public IGroupTypeRepository GroupType { get;  }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
