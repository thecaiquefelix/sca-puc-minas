using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCA.Gateway.Domain;

namespace SCA.Gateway.Controllers
{
    [ApiController]
    [Route("api/v1/assets")]
    public class AssetController : BaseController
    {
        const string baseURL = "http://localhost:5000";

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var url = $"{baseURL}/api/v1/assets";

            return await GetListAsync<Asset>(url);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var url = $"{baseURL}/api/v1/assets/{id}";

            return await GetAsync<Asset>(url);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertAsync([FromBody]Asset asset)
        {
            var url = $"{baseURL}/api/v1/assets";

            return await PostAsync(url, asset);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAsync([FromBody]Asset asset)
        {
            var url = $"{baseURL}/api/v1/assets";

            return await PutAsync(url, asset);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var url = $"{baseURL}/api/v1/assets/{id}";
            return await DeleteAsync(url);
        }
    }
}
