using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCA.Gateway.Domain;

namespace SCA.Gateway.Controllers
{
    [ApiController]
    [Route("api/v1/monitors")]
    public class MonitorController : BaseController
    {
        const string baseURL = "http://localhost:5005";

        [HttpGet("dam/{damId:int}/metric/{metricId:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllAsync(int damId, int metricId)
        {
            var url = $"{baseURL}/api/v1/monitors/dam/{damId}/metric/{metricId}";

            return await GetListAsync<Monitor>(url);
        }

    }
}
