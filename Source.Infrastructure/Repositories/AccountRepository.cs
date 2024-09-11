using Dapper;
using Source.Core.Contracts.Basic;
using Source.Core.Contracts;
using Source.Core.DTOs;
using Source.Core.Objects;
using Source.Infrastructure.Infralayer;
using Source.Infrastructure.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Source.Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository, IAccountRepository, IGenericRepository
    {
        public AccountRepository(SqlConnectionFactory conn) : base(conn) { }

        public async Task<CIDTBL?> FindUserAsync(string UserName, string Password)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@UserName", UserName, DbType.String);
            _parameters.Add("@Password", Password, DbType.String);

            var _result = await base.QueryAsync<CIDTBL>(
               @"SELECT * FROM [dbo].[CIDTBL] WITH(NOLOCK) where ID = @UserName and [PASSWORD] = @Password", _parameters, "KVTWLConnection"
            );
            return _result.AsQueryable().FirstOrDefault();
        }


        public async Task<CIDTBL?> FindUserAsync(string UserName)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@UserName", UserName, DbType.String);

            var _result = await base.QueryAsync<CIDTBL>(
               @"SELECT * FROM [dbo].[CIDTBL] WITH(NOLOCK) where ID = @UserName", _parameters, "KVTWLConnection"
            );
            return _result.AsQueryable().FirstOrDefault();
        }
    }
}
