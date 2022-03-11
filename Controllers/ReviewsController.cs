using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using PrintLayer.Models;
using PrintLayer.Services.Interfaces;

namespace PrintLayer.Controllers
{
    [Route("[controller]")]
    public class ReviewsController : Controller 
    {
        private readonly ICommonService<Review> _commonService;
        private readonly IAuthService _authService;

        public ReviewsController( ICommonService<Review> commonService, IAuthService authService)
        {
            _commonService = commonService;
            _authService = authService;
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Review> Get()
        {
            var reviews = _commonService.GetAll();
            return reviews;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Review> GetById(Guid id)
        {
            var review = await _commonService.FindAsync(id);
            return review;
        }

        [HttpDelete]
        public async Task Delete([FromBody] Review review)
        {
            await _commonService.DeleteAsync(review);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteById(Guid id)
        {
            await _commonService.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Add([FromBody] Review review)
        {
            review.User = await _authService.GetUserByLoginAsync("admin");
            await _commonService.AddAsync(review);
        }

        [HttpPut]
        public async Task Update([FromBody] Review review)
        {
            await _commonService.UpdateAsync(review);
        }

    }
}
