using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintLayer.Models;
using PrintLayer.Services.Interfaces;

namespace PrintLayer.Controllers
{
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly ICommonService<Order> _commonService;
        private readonly IAuthService _authService;
        public OrdersController(ICommonService<Order> commonService, IAuthService authService)
        {
            _commonService = commonService;
            _authService = authService;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var orders = _commonService.GetAll();
            return orders;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Order> GetById(Guid id)
        {
            var order = await _commonService.FindAsync(id);
            return order;
        }

        [HttpDelete]
        public async Task Delete([FromBody] Order order)
        {
            await _commonService.DeleteAsync(order);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteById(Guid id)
        {
            await _commonService.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Add([FromBody] Order order)
        {
            await _commonService.AddAsync(order);
        }

        [HttpPut]
        public async Task Update([FromBody] Order order)
        {
            await _commonService.UpdateAsync(order);
        }
    }
}
