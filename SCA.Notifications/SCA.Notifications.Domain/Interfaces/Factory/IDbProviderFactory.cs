using System.Data.Common;

namespace SCA.Notifications.Domain.Interfaces.Factory
{
    public interface IDbProviderFactory
    {
        DbConnection CreateScopedConnection();
    }
}
