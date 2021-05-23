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
            string accountSid = "AC8704b0d533d5f618957f1dc1e21b7e87";
            string authToken = "f90779d288805434027b96c1147f9f8b";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: notification.Message,
                from: new Twilio.Types.PhoneNumber("+14432513359"),
                to: new Twilio.Types.PhoneNumber("+5511989030338")
            );

            return Ok();
        }
    }
}
