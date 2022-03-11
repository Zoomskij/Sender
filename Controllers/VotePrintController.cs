using Microsoft.AspNetCore.Mvc;
using SenderApp.Models;
using SenderApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenderApp.Controllers
{
    [Route("[controller]")]
    public class VotePrintController : Controller
    {
        private readonly IEmailService _votePrintService;

        public VotePrintController(IEmailService votePrintService)
        {
            _votePrintService = votePrintService;
        }
    }
}
