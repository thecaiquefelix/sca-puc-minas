using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SCA.Monitors.Domain.Entities;
using SCA.Monitors.Domain.Interfaces.Factory;
using SCA.Monitors.Domain.Interfaces.Repository;

namespace SCA.Monitors.Data.Repository
{
    public class MonitorRepository : IMonitorRepository
    {

        private readonly IDbProviderFactory _dbProviderFactory;

        public MonitorRepository(IDbProviderFactory dbProviderFactory)
        {
            _dbProviderFactory = dbProviderFactory;
        }

        public async Task<List<Monitor>> GetByDamAndMetricAsync(int damId, int metricId)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"SELECT TOP(10) [Id]
                                                  ,[DamId]
                                                  ,[MetricId]
                                                  ,[Date]
                                                  ,[Value]
                                    FROM[DatabaseSCA].[dbo].[Sensors] WITH(NOLOCK)
                                    WHERE DamId = @DamId AND MetricId = @MetricId
                                    ORDER BY Id DESC";

            var Monitors = await connection.QueryAsync<Monitor>(script, new { DamId = damId, MetricId  = metricId });

            return Monitors.ToList();
        }

    }
}
