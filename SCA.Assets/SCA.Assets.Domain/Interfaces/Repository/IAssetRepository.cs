using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Assets.Domain.Entities;

namespace SCA.Assets.Domain.Interfaces.Repository
{
    public interface IAssetRepository
    {
        Task<List<Asset>> GetAllAsync();
        Task<Asset> GetById(int id);
        Task InsertAsync(Asset asset);
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(int id);
    }
}
