using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrintLayer.Data;
using PrintLayer.Models;
using PrintLayer.Repositories.Interfaces;

namespace PrintLayer.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Context _context;
        private readonly DbSet<User> _dbSet;

        public AuthRepository(Context context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public async Task<User> GetUserByCredentialsAsync(string login, string passwordHash)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == login && x.PasswordHash == passwordHash);
            return user;
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == login);
            return user;
        }

        public async Task AddUser(string login, string passwordHash)
        {
            var user = new User
            {
                Email = login,
                PasswordHash = passwordHash
            };
            await _dbSet.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
