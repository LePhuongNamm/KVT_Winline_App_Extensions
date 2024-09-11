using Dapper;
using Microsoft.Data.SqlClient;
using Source.Core.Contracts.Basic;
using Source.Infrastructure.Infralayer;
using System.Data;

namespace Source.Infrastructure.Repositories.Basic
{
    public class GenericRepository : IGenericRepository
    {
        private readonly SqlConnectionFactory _conn;
        public GenericRepository(SqlConnectionFactory conn)
        {
            _conn = conn;
        }

        public DataTable Query(string query, string conn)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var _connection = _conn.CreateConnection(conn))
                {
                    _connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = _connection;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }

                    _connection.Close();
                }
            }
            catch { }
            return dt;
        }

        public async Task<List<T>> QueryAsync<T>(string query, DynamicParameters? parameters, string conn)
        {
            List<T> _result = new List<T>();
            try
            {
                using (var _connection = _conn.CreateConnection(conn))
                {
                    _connection.Open();
                    var _source = await _connection.QueryAsync<T>(sql: query, param: parameters, commandTimeout: 360);
                    if (_source.Any())
                        _result = _source.ToList();
                    _connection.Close();
                }
            }
            catch { }
            return _result;
        }

        public async Task<int> ExecuteAsync(string query, DynamicParameters? parameters, string conn)
        {
            int _result;
            try
            {
                using (var _connection = _conn.CreateConnection(conn))
                {
                    _connection.Open();
                    _result = await _connection.ExecuteAsync(sql: query, param: parameters, commandTimeout: 360);
                    _connection.Close();
                }
            }
            catch
            {
                _result = 0;
            }

            return _result;
        }
    }
}
