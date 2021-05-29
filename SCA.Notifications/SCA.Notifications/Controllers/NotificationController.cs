using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCA.Notifications.Application.Interfaces;
using SCA.Notifications.Model;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SCA.Notifications.Controllers
{
    [Route("api/v1/notifications")]
    [ApiController]
    public class NotificationController : BaseController
    {
        private readonly INotificationAppService _notificationAppService;

        public NotificationController(INotificationAppService notificationAppService)
        {
            _notificationAppService = notificationAppService;
        }


        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] NotificationModel notification)
        {
            var result = await _notificationAppService.SendAsync(notification.DamId, notification.Message);  

            return Response(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _notificationAppService.GetAllAsync();
            return Response(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _notificationAppService.GetById(id);
            return Response(result);
        }
    }
}
