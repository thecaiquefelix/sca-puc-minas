using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCA.Gateway.Domain;
namespace SCA.Gateway.Controllers
{

    [ApiController]
    [Route("api/v1/contacts")]
    public class ContactController : BaseController
    {
        const string baseURL = "http://localhost:5006";

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> InsertAsync([FromBody]Contact contact)
        {
            var url = $"{baseURL}/api/v1/contacts";

            return await PostAsync(url, contact);
        }
    }
}
