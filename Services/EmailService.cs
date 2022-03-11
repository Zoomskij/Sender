using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenderApp.Models;
using SenderApp.Repositories.Interfaces;
using SenderApp.Services.Interfaces;

namespace SenderApp.Services
{
    public class EmailService : CommonService<Email>, IEmailService
    {
        private readonly IGenericRepository<Email> _repository;

        public EmailService(IGenericRepository<Email> repository) : base(repository)
        {
            _repository = repository;
        }

        public virtual async Task Start(Email entity)
        {
            if (entity == null) return;
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public virtual async Task Stop(Email entity)
        {
            if (entity == null) return;
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }
        
    }
}
