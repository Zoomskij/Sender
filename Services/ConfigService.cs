using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SenderApp.Models;
using SenderApp.Repositories.Interfaces;
using SenderApp.Services.Interfaces;

namespace SenderApp.Services
{
    public class ConfigService : CommonService<Config>, IConfigService
    {
        private readonly IGenericRepository<Config> _repository;

        public ConfigService(IGenericRepository<Config> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
