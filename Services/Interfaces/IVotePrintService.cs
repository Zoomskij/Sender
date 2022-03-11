using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintLayer.Models;

namespace PrintLayer.Services.Interfaces
{
    public interface IVotePrintService : ICommonService<VotePrint>
    {
        Task AddVote(VotePrint entity);

        Task SubtractVote(VotePrint entity);
    }
}
