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
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IEnumerable<Email> Get()
        {
            var news = _emailService.GetAll();
            return news;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Email> GetById(Guid id)
        {
            var news = await _emailService.FindAsync(id);
            return news;
        }

        [HttpDelete]
        public async Task Delete([FromBody] Email news)
        {
            await _emailService.DeleteAsync(news);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteById(Guid id)
        {
            await _emailService.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Add([FromBody] Email news)
        {
            await _emailService.AddAsync(news);
        }

        [HttpPut]
        public async Task Update([FromBody] Email news)
        {
            await _emailService.UpdateAsync(news);
        }

        [HttpGet]
        public async Task Start([FromBody] Email news)
        {
            await _emailService.StartAsync(news);
        }

        [HttpGet]
        public async Task Stop([FromBody] Email news)
        {
            await _emailService.StopAsync(news);
        }
    }
}
