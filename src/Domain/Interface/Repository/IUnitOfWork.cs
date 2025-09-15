using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IAttemptsRepository Attempts { get; }
        public IRefreshTokenRepository Tokens { get; }
        public IRoleRepository Roles { get; }
        public IAdressRepository Adresses { get; }

        Task<int> CommitAsync();
        void Dispose();
    }
}
