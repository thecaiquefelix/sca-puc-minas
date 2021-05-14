using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dommel;
using SCA.Assets.Domain.Entities;
using SCA.Assets.Domain.Interfaces.Factory;
using SCA.Assets.Domain.Interfaces.Repository;

namespace SCA.Assets.Data.Repository
{
    public class AssetRepository : IAssetRepository
    {

        private readonly IDbProviderFactory _dbProviderFactory;

        public AssetRepository(IDbProviderFactory dbProviderFactory)
        {
            _dbProviderFactory = dbProviderFactory;
        }

        public async Task<List<Asset>> GetAllAsync()
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"SELECT [Id]
                                          ,[Name]
                                          ,[Manufacturer]
                                          ,[Category]
                                          ,[ManufactureDate]
                                          ,[Serial]
                                          ,[Active]
                                    FROM[DatabaseSCA].[dbo].[Assets] WITH(NOLOCK)
                                    WHERE Active = 1";

            var assets = await connection.QueryAsync<Asset>(script);

            return assets.ToList();
        }

        public async Task<Asset> GetById(int id)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"SELECT [Id]
                                          ,[Name]
                                          ,[Manufacturer]
                                          ,[Category]
                                          ,[ManufactureDate]
                                          ,[Serial]
                                    FROM[DatabaseSCA].[dbo].[Assets] WITH(NOLOCK)
                                    WHERE Id = @Id AND Active = 1";

            var asset = await connection.QueryFirstOrDefaultAsync<Asset>(script, new { Id = id });

            return asset;
        }

        public async Task InsertAsync(Asset asset)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            await connection.InsertAsync(asset);
        }

        public async Task UpdateAsync(Asset asset)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            await connection.UpdateAsync(asset);
        }

        public async Task DeleteAsync(int id)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"UPDATE [DatabaseSCA].[dbo].[Assets]
                                    SET [Active] = 0
                                    WHERE Id = @Id";

            await connection.ExecuteAsync(script, new { Id = id});
        }
    }
}
