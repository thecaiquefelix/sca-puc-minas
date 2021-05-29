using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dommel;
using SCA.Notifications.Domain.Entities;
using SCA.Notifications.Domain.Interfaces.Factory;
using SCA.Notifications.Domain.Interfaces.Repository;

namespace SCA.Notifications.Data.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IDbProviderFactory _dbProviderFactory;

        public NotificationRepository(IDbProviderFactory dbProviderFactory)
        {
            _dbProviderFactory = dbProviderFactory;
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"SELECT [Id]
                                          ,[DamId]
                                          ,[Date]
                                          ,[Message]
                                    FROM[DatabaseSCA].[dbo].[Notifications] WITH(NOLOCK)";

            var notifications = await connection.QueryAsync<Notification>(script);

            return notifications.ToList();
        }

        public async Task<Notification> GetById(int id)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"SELECT [Id]
                                          ,[DamId]
                                          ,[Date]
                                          ,[Message]
                                    FROM[DatabaseSCA].[dbo].[Notifications] WITH(NOLOCK)
                                    WHERE Id = @Id";

            var notification = await connection.QueryFirstOrDefaultAsync<Notification>(script, new { Id = id });

            return notification;
        }

        public async Task InsertAsync(Notification notification)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            await connection.InsertAsync(notification);
        }
    }
}
