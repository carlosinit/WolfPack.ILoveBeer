using System.Data;

namespace WolfPack.ILoveBeer.Infrastructure.Persistence.Contracts
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection();
    }
}