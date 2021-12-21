using System.Data;
using System.Data.Common;

namespace Codecool.CodecoolShop.Services
{
    public interface IDbConnectionService
    {
        string _connectionString { get; }
        DbProviderFactory factory { get; }
        string provider { get; }
        IDbConnection GetConnection();
    }
}