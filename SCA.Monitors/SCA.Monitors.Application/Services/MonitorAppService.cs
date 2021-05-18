using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCA.Monitors.Application.Interfaces;
using SCA.Monitors.Domain.Entities;
using SCA.Monitors.Domain.Interfaces.Repository;

namespace SCA.Monitors.Application.Services
{
    public class MonitorAppService : IMonitorAppService
    {
        private readonly IMonitorRepository _MonitorRepository;

        public MonitorAppService(IMonitorRepository MonitorRepository)
        {
            _MonitorRepository = MonitorRepository;
        }

        public async Task<Result<List<Monitor>>>GetByDamAndMetricAsync(int damId, int metricId)
        {
            try
            {
                var Monitors = await _MonitorRepository.GetByDamAndMetricAsync(damId, metricId);

                return new Result<List<Monitor>>(Monitors.OrderBy(x => x.Date).ToList());
            }
            catch (Exception ex)
            {
                return new Result<List<Monitor>>(null, "Erro ao consultar monitor");
            }
        } 
    }
}
