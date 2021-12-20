using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace Codecool.CodecoolShop.Services
{
    public class DbConnectionService : IDbConnectionService
    {
        private readonly IConfiguration configuration;

        public DbProviderFactory factory { get; }
        public string provider { get; }
        public string _connectionString { get; }

        public DbConnectionService(IConfiguration config)
        {
            configuration = config;
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
            provider = "System.Data.SqlClient";
            factory = DbProviderFactories.GetFactory(provider);
        }



        public void Add(string name, string lastName) // pod testowanie połączenia, potem wyjebać
        {
            using (var conn = factory.CreateConnection())
            {
                conn.ConnectionString = _connectionString;
                conn.Open();
                var command = factory.CreateCommand();
                command.Connection = conn;
                command.CommandText = $"INSERT INTO users (name, password) " +
                                      $"VALUES('{name}', '{lastName}');";
                command.ExecuteNonQuery();
            }
        }
    }
}
