using System.Data.Common;

namespace SCA.Assets.Domain.Interfaces.Factory
{
    public interface IDbProviderFactory
    {
        DbConnection CreateScopedConnection();
    }
}
