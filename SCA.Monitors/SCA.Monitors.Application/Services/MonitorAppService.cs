using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCA.Monitors.Application.Interfaces;
using SCA.Monitors.Domain.DTO;
using SCA.Monitors.Domain.Entities;
using SCA.Monitors.Domain.Enum;
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

        public async Task<Result<MonitorResponse>>GetByDamAndMetricAsync(int damId, int metricId)
        {
            try
            {
                var monitors = await _MonitorRepository.GetByDamAndMetricAsync(damId, metricId);

                var values = monitors.Select(x => x.Value).Average();

                var status = StatusEnum.Normal;
                var critical = GetMaxValues(metricId);

                if (values > critical)
                {
                    status = StatusEnum.Critical;
                }
                else if (values > (critical / 2))
                {
                    status = StatusEnum.Warning;
                }

                var result = new MonitorResponse
                {
                    Monitors = monitors.OrderBy(x => x.Date).ToList(),
                    Status = status,
                    Message = GetMessage(metricId, status)
                };

                return new Result<MonitorResponse>(result);
            }
            catch (Exception ex)
            {
                return new Result<MonitorResponse>(null, "Erro ao consultar monitor");
            }
        }

        private int GetMaxValues(int metricId)
        {
            return metricId switch
            {
                1 => 30,
                2 => 10,
                3 => 10,
                4 => 20,
                _ => 10,
            };
        }

        private string GetMessage(int metricId, StatusEnum status)
        {
            return metricId switch
            {
                1 => GetMessageDisplacement(status),
                2 => GetMessagePiezometer(status),
                3 => GetMessageInclinometer(status),
                4 => GetMessageWater(status),
                _ => string.Empty,
            };
        }

        private string GetMessageDisplacement(StatusEnum status)
        {
            return status switch
            {
                StatusEnum.Normal => string.Empty,
                StatusEnum.Warning => "Atenção: Nivel de Descolocamento",
                StatusEnum.Critical => "Critico: Nivel de Descolocamento",
                _ => string.Empty,
            };
        }

        private string GetMessagePiezometer(StatusEnum status)
        {
            return status switch
            {
                StatusEnum.Normal => string.Empty,
                StatusEnum.Warning => "Atenção: Nivel do Piezometro",
                StatusEnum.Critical => "Critico: Nivel do Piezometro",
                _ => string.Empty,
            };
        }


        private string GetMessageInclinometer(StatusEnum status)
        {
            return status switch
            {
                StatusEnum.Normal => string.Empty,
                StatusEnum.Warning => "Atenção: Nivel do inclinometro",
                StatusEnum.Critical => "Critico: Nivel do inclinometro",
                _ => string.Empty,
            };
        }


        private string GetMessageWater(StatusEnum status)
        {
            return status switch
            {
                StatusEnum.Normal => string.Empty,
                StatusEnum.Warning => "Atenção: Nivel da água",
                StatusEnum.Critical => "Critico: Nivel da água",
                _ => string.Empty,
            };
        }


    }
}
