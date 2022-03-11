using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintLayer.Models;

namespace PrintLayer.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> GetUserByCredentialsAsync(string login, string passwordHash);
        Task<User> GetUserByLoginAsync(string login);
        Task AddUser(string login, string passwordHash);
    }
}
