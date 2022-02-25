using CompanyWebApi.Core.Domain;
using CompanyWebApi.Persistence;

namespace CompanyWebApi.Controllers
{
    public class OrderController:MainController<Order>
    {
        public OrderController(CompanyContext context) : base(context)
        {
        }
    }
}
