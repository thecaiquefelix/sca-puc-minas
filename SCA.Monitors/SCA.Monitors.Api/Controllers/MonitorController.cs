using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCA.Monitors.Application.Interfaces;
using SCA.Monitors.Domain.Entities;

namespace SCA.Monitors.Api.Controllers
{
    [ApiController]
    [Route("api/v1/monitors")]
    public class MonitorController : BaseController
    {

        private readonly IMonitorAppService _MonitorAppService;

        public MonitorController(IMonitorAppService MonitorAppService)
        {
            _MonitorAppService = MonitorAppService;
        }

        [HttpGet("dam/{damId:int}/metric/{metricId:int}")]
        public async Task<IActionResult> GetAllAsync(int damId, int metricId)
        {
            var result = await _MonitorAppService.GetByDamAndMetricAsync(damId, metricId);
            return Response(result);
        }

    }
}
