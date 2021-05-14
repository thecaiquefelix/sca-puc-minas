using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Assets.Domain.Entities;

namespace SCA.Assets.Application.Interfaces
{
    public interface IAssetAppService
    {
        Task<Result<List<Asset>>> GetAllAsync();
        Task<Result<Asset>> GetById(int id);
        Task<Result> InsertAsync(Asset asset);
        Task<Result> UpdateAsync(Asset asset);
        Task<Result> DeleteAsync(int id);
    }
}
