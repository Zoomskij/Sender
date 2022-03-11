using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintLayer.Models;
using PrintLayer.Services;
using PrintLayer.Services.Interfaces;

namespace PrintLayer.Controllers
{
    [Route("[controller]")] 
    public class NewsController : Controller
    {
        private readonly ICommonService<News> _commonService;

        public NewsController(ICommonService<News> commonService)
        {
            _commonService = commonService;
        }

        [HttpGet]
        public IEnumerable<News> Get()
        {
            var news = _commonService.GetAll();
            return news;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<News> GetById(Guid id)
        {
            var news = await _commonService.FindAsync(id);
            return news;
        }

        [HttpDelete]
        public async Task Delete([FromBody] News news)
        {
            await _commonService.DeleteAsync(news);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteById(Guid id)
        {
            await _commonService.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Add([FromBody] News news)
        {
            await _commonService.AddAsync(news);
        }

        [HttpPut]
        public async Task Update([FromBody] News news)
        {
            await _commonService.UpdateAsync(news);
        }
    }
}
