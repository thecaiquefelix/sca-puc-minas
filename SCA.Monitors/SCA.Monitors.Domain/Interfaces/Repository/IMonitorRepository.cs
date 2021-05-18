using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Monitors.Domain.Entities;

namespace SCA.Monitors.Domain.Interfaces.Repository
{
    public interface IMonitorRepository
    {
        Task<List<Monitor>> GetByDamAndMetricAsync(int damId, int metricId);
    }
}
