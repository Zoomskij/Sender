using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenderApp.Models;
using SenderApp.Services;
using SenderApp.Services.Interfaces;

namespace SenderApp.Controllers
{
    [Route("[controller]")] 
    public class NewsController : Controller
    {
        private readonly ICommonService<Email> _commonService;

        public NewsController(ICommonService<Email> commonService)
        {
            _commonService = commonService;
        }

        [HttpGet]
        public IEnumerable<Email> Get()
        {
            var news = _commonService.GetAll();
            return news;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Email> GetById(Guid id)
        {
            var news = await _commonService.FindAsync(id);
            return news;
        }

        [HttpDelete]
        public async Task Delete([FromBody] Email news)
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
        public async Task Add([FromBody] Email news)
        {
            await _commonService.AddAsync(news);
        }

        [HttpPut]
        public async Task Update([FromBody] Email news)
        {
            await _commonService.UpdateAsync(news);
        }
    }
}
