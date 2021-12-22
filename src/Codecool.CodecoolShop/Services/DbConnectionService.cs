using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace Codecool.CodecoolShop.Services
{
    public class DbConnectionService : IDbConnectionService
    {
        private readonly IConfiguration configuration;

        private DbProviderFactory _factory;
        private string _provider;
        private string _connectionString;

        public DbConnectionService(IConfiguration config)
        {
            configuration = config;
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
            _provider = "System.Data.SqlClient";
            _factory = DbProviderFactories.GetFactory(_provider);
        }

        public IDbConnection GetConnection()
        {
            var conn = _factory.CreateConnection();
            conn.ConnectionString = _connectionString;
            return conn;
        }
    }
}
