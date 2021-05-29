using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCA.Gateway.Domain;

namespace SCA.Gateway.Controllers
{
    [ApiController]
    [Route("api/v1/notifications")]
    public class NotificationController : BaseController
    {
        const string baseURL = "http://localhost:5006";

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SendAsync([FromBody] NotificationRequest notification)
        {
            var url = $"{baseURL}/api/v1/notifications";

            return await PostAsync(url, notification);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var url = $"{baseURL}/api/v1/notifications";

            return await GetListAsync<NotificationResponse>(url);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var url = $"{baseURL}/api/v1/notifications/{id}";

            return await GetAsync<NotificationResponse>(url);
        }
    }
}
