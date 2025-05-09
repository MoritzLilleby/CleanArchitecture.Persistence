using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.ADO.NET_SQL
{
    public interface IAdoContext
    {
        SqlConnection CreateConnection();
    }

    internal class AdoContext : IAdoContext
    {

        private readonly string _connectionString;

        public AdoContext(string sqlConnectionString)
        {
            _connectionString = sqlConnectionString;
        }

        public SqlConnection CreateConnection() => new(_connectionString);

    }
}
