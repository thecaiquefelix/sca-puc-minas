using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCA.Notifications.Domain;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SCA.Notifications.Controllers
{
    [Route("api/v1/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] Notification notification)
        {
            string accountSid = "";
            string authToken = "";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: notification.Message,
                from: new Twilio.Types.PhoneNumber(""),
                to: new Twilio.Types.PhoneNumber("")
            );

            return Ok();
        }
    }
}
