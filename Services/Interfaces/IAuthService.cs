using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintLayer.Models;

namespace PrintLayer.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> LoginAsync(string login, string password);
        Task<User> CreateUserAsync(string login, string password);
        Task<User> GetUserByLoginAsync(string login);
    }
}
