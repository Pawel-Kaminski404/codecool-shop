using System.Data;
using System.Data.Common;

namespace Codecool.CodecoolShop.Services
{
    public interface IDbConnectionService
    {
        IDbConnection GetConnection();
    }
}