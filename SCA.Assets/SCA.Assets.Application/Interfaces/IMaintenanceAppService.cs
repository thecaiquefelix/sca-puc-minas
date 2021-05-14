using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Assets.Domain.DTO;
using SCA.Assets.Domain.Entities;

namespace SCA.Assets.Application.Interfaces
{
    public interface IMaintenanceAppService
    {
        Task<Result<List<MaintenanceDTO>>> GetAllAsync();
        Task<Result<Maintenance>> GetById(int id);
        Task<Result> InsertAsync(Maintenance maintenance);
        Task<Result> UpdateAsync(Maintenance maintenance);
        Task<Result> DeleteAsync(int id);
    }
}
