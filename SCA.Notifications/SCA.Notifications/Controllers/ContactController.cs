using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCA.Notifications.Application.Interfaces;
using SCA.Notifications.Domain.Entities;

namespace SCA.Notifications.Controllers
{
    [Route("api/v1/contacts")]
    [ApiController]
    public class ContactController : BaseController
    {
        private readonly IContactAppService _contactAppService;

        public ContactController(IContactAppService contactAppService)
        {
            _contactAppService = contactAppService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] Contact contact)
        {
            var result = await _contactAppService.InsertAsync(contact);

            return Response(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] string phone)
        {
            var result = await _contactAppService.DeleteAsync(phone);

            return Response(result);
        }
    }
}


//[Route("api/v1/contacts")]
//[ApiController]
//public class ContactController : BaseController
//{
//    private readonly IContactAppService _contactAppService;

//    public ContactController(IContactAppService contactAppService)
//    {
//        _contactAppService = contactAppService;
//    }

//    [HttpPost]
//    public async Task<IActionResult> InsertAsync([FromBody] Contact contact)
//    {
//        var result = await _contactAppService.InsertAsync(contact);

//        return Response(result);
//    }

//    [HttpDelete("{phone:string}")]
//    public async Task<IActionResult> DeleteAsync(string phone)
//    {
//        var result = await _contactAppService.DeleteAsync(phone);

//        return Response(result);
//    }
//}