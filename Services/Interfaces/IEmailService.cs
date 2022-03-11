using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenderApp.Models;

namespace SenderApp.Services.Interfaces
{
    public interface IEmailService : ICommonService<Email>
    {
        Task Start(Email entity);

        Task Stop(Email entity);
    }
}
