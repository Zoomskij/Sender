using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintLayer.Models;
using PrintLayer.Repositories.Interfaces;
using PrintLayer.Services.Interfaces;

namespace PrintLayer.Services
{
    public class OrderService : CommonService<Order>, IOrderService
    {
        private readonly IGenericRepository<Order> _repository;

        public OrderService(IGenericRepository<Order> repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
