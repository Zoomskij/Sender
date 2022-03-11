using Microsoft.AspNetCore.Mvc;
using PrintLayer.Models;
using PrintLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintLayer.Controllers
{
    [Route("[controller]")]
    public class VotePrintController : Controller
    {
        private readonly IVotePrintService _votePrintService;

        public VotePrintController(IVotePrintService votePrintService)
        {
            _votePrintService = votePrintService;
        }
    }
}
