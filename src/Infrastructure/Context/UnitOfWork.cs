using Domain.Interface.Repository;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbConfig _context;

        public IUserRepository Users { get; }
        public IAttemptsRepository Attempts { get; }
        public IRefreshTokenRepository Tokens { get; }
        public IRoleRepository Roles { get; }
        public IAdressRepository Adresses { get; }

        public UnitOfWork(DbConfig context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Tokens = new TokenRepository(_context);
            Attempts = new AttemptRepository(_context);
            Adresses = new AdressRepository(_context);
            Roles = new RoleRepository(_context);
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
