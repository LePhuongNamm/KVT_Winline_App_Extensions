using Source.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Contracts
{
    public interface IAccountRepository
    {
        Task<CIDTBL?> FindUserAsync(string UserName, string Password);
        Task<CIDTBL?> FindUserAsync(string UserName);
    }
}
