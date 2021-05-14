using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dommel;
using SCA.Assets.Domain.DTO;
using SCA.Assets.Domain.Entities;
using SCA.Assets.Domain.Interfaces.Factory;
using SCA.Assets.Domain.Interfaces.Repository;

namespace SCA.Assets.Data.Repository
{
    public class MaintenanceRepository : IMaintenanceRepository
    {

        private readonly IDbProviderFactory _dbProviderFactory;

        public MaintenanceRepository(IDbProviderFactory dbProviderFactory)
        {
            _dbProviderFactory = dbProviderFactory;
        }

        public async Task<List<MaintenanceDTO>> GetAllAsync()
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"SELECT M.[Id]
                                          ,M.[AssetId]
                                          ,A.[Name] AS AssetName
                                          ,M.[Type]
                                          ,M.[Date]
                                          ,M.[Status]
                                          ,M.[Active]
                                    FROM [DatabaseSCA].[dbo].[Maintenances] AS M WITH(NOLOCK)
                                    INNER JOIN [DatabaseSCA].[dbo].[Assets] AS A WITH(NOLOCK) ON A.Id = M.AssetId
                                    WHERE M.Active = 1";

            var maintenances = await connection.QueryAsync<MaintenanceDTO>(script);

            return maintenances.ToList();
        }

        public async Task<Maintenance> GetById(int id)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"SELECT [Id]
                                          ,[AssetId]
                                          ,[Type]
                                          ,[Date]
                                          ,[Status]
                                          ,[Active]
                                    FROM [DatabaseSCA].[dbo].[Maintenances] WITH(NOLOCK)
                                    WHERE Id = @Id AND Active = 1";

            var maintenance = await connection.QueryFirstOrDefaultAsync<Maintenance>(script, new { Id = id });

            return maintenance;
        }

        public async Task InsertAsync(Maintenance maintenance)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            await connection.InsertAsync(maintenance);
        }

        public async Task UpdateAsync(Maintenance maintenance)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            await connection.UpdateAsync(maintenance);
        }

        public async Task DeleteAsync(int id)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"UPDATE [DatabaseSCA].[dbo].[Maintenances]
                                    SET [Active] = 0
                                    WHERE Id = @Id";

            await connection.ExecuteAsync(script, new { Id = id});
        }
    }
}
