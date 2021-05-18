using System.Data.Common;

namespace SCA.Monitors.Domain.Interfaces.Factory
{
    public interface IDbProviderFactory
    {
        DbConnection CreateScopedConnection();
    }
}
