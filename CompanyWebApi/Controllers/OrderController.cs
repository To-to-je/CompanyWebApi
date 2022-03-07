using AutoMapper;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DTOs;
using CompanyWebApi.Persistence;

namespace CompanyWebApi.Controllers
{
    public class OrderController:MainController<Order, OrderDto>
    {
        public OrderController(CompanyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

