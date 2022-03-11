using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintLayer.Models;
using PrintLayer.Repositories.Interfaces;
using PrintLayer.Services.Interfaces;

namespace PrintLayer.Services
{
    public class VotePrintService : CommonService<VotePrint>, IVotePrintService
    {
        private readonly IGenericRepository<VotePrint> _repository;

        public VotePrintService(IGenericRepository<VotePrint> repository) : base(repository)
        {
            _repository = repository;
        }

        public virtual async Task AddVote(VotePrint entity)
        {
            if (entity == null) return;
            entity.Votes++;
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public virtual async Task SubtractVote(VotePrint entity)
        {
            if (entity == null) return;
            entity.Votes--;
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }
        
    }
}
