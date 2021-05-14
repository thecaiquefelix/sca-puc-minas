using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCA.Gateway.Domain;

namespace SCA.Gateway.Controllers
{
    [ApiController]
    [Route("api/v1/maintenances")]
    public class MaintenanceController : BaseController
    {
        const string baseURL = "http://localhost:5000";

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var url = $"{baseURL}/api/v1/maintenances";

            return await GetListAsync<Maintenance>(url);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var url = $"{baseURL}/api/v1/maintenances/{id}";

            return await GetAsync<Maintenance>(url);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertAsync([FromBody]Maintenance maintenance)
        {
            var url = $"{baseURL}/api/v1/maintenances";

            return await PostAsync(url, maintenance);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAsync([FromBody]Maintenance maintenance)
        {
            var url = $"{baseURL}/api/v1/maintenances";

            return await PutAsync(url, maintenance);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var url = $"{baseURL}/api/v1/maintenances/{id}";
            return await DeleteAsync(url);
        }
    }
}
