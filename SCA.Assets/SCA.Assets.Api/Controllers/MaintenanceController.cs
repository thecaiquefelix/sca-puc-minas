using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCA.Assets.Application.Interfaces;
using SCA.Assets.Domain.Entities;

namespace SCA.Assets.Api.Controllers
{
    [ApiController]
    [Route("api/v1/maintenances")]
    public class MaintenanceController : BaseController
    {

        private readonly IMaintenanceAppService _maintenanceAppService;

        public MaintenanceController(IMaintenanceAppService maintenanceAppService)
        {
            _maintenanceAppService = maintenanceAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _maintenanceAppService.GetAllAsync();
            return Response(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _maintenanceAppService.GetById(id);
            return Response(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody]Maintenance maintenance)
        {
            var result = await _maintenanceAppService.InsertAsync(maintenance);
            return Response(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]Maintenance maintenance)
        {
            var result = await _maintenanceAppService.UpdateAsync(maintenance);
            return Response(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _maintenanceAppService.DeleteAsync(id);
            return Response(result);
        }
    }
}
