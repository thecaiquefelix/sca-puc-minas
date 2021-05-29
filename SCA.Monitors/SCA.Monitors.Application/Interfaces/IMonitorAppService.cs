using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Monitors.Domain.DTO;
using SCA.Monitors.Domain.Entities;

namespace SCA.Monitors.Application.Interfaces
{
    public interface IMonitorAppService
    {
        Task<Result<MonitorResponse>> GetByDamAndMetricAsync(int damId, int metricId);
    }
}
