using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Assets.Domain.DTO;
using SCA.Assets.Domain.Entities;

namespace SCA.Assets.Domain.Interfaces.Repository
{
    public interface IMaintenanceRepository
    {
        Task<List<MaintenanceDTO>> GetAllAsync();
        Task<Maintenance> GetById(int id);
        Task InsertAsync(Maintenance maintenance);
        Task UpdateAsync(Maintenance maintenance);
        Task DeleteAsync(int id);
    }
}
