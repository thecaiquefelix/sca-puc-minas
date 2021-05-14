using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCA.Assets.Application.Interfaces;
using SCA.Assets.Domain.Entities;

namespace SCA.Assets.Api.Controllers
{
    [ApiController]
    [Route("api/v1/assets")]
    public class AssetController : BaseController
    {

        private readonly IAssetAppService _assetAppService;

        public AssetController(IAssetAppService assetAppService)
        {
            _assetAppService = assetAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _assetAppService.GetAllAsync();
            return Response(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _assetAppService.GetById(id);
            return Response(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody]Asset asset)
        {
            var result = await _assetAppService.InsertAsync(asset);
            return Response(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]Asset asset)
        {
            var result = await _assetAppService.UpdateAsync(asset);
            return Response(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _assetAppService.DeleteAsync(id);
            return Response(result);
        }
    }
}
