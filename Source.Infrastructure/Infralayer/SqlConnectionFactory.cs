using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Source.Infrastructure.Infralayer
{
    public class SqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection CreateConnection(string SqlConnection)
           => new SqlConnection(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(_configuration[$"AppConfig:{SqlConnection}"]!)));
    }
}
