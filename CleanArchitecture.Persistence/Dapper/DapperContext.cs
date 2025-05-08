using Microsoft.Data.SqlClient;
using System.Data;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("CleanArchitecture.Persistence.IntegrationTest")]
namespace CleanArchitecture.Persistence.Dapper
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }

    internal class DapperContext : IDapperContext
    {

        private readonly string _connectionString;

        public DapperContext(string sqlConnectionString)
        {
            _connectionString = sqlConnectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
