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
        public IActionResult Get()
        {
            var emails = _emailService.GetAll();
            return Ok(emails);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var email = await _emailService.FindAsync(id);
            return Ok(email);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Email email)
        {
            await _emailService.DeleteAsync(email);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            await _emailService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Email news)
        {
            await _emailService.AddAsync(news);
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Email news)
        {
            await _emailService.UpdateAsync(news);
            return Ok();
        }

        [HttpGet]
        [Route("start")]
        public async Task<IActionResult> Start()
        {
            var result = await _emailService.StartAsync();
            if (result != true)
                return BadRequest();
            return Ok();
        }

        [HttpGet]
        [Route("stop")]
        public async Task<IActionResult> Stop()
        {
            var result = await _emailService.StopAsync();
            if (result != true)
                return BadRequest();
            return Ok();
        }
    }
}
