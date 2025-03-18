using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Dapper
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
