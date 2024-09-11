using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Contracts.Basic
{
    public interface IGenericRepository
    {
        DataTable Query(string query, string conn);
        Task<List<T>> QueryAsync<T>(string query, DynamicParameters? parameters, string conn);
        Task<int> ExecuteAsync(string query, DynamicParameters? parameters, string conn);
    }
}
