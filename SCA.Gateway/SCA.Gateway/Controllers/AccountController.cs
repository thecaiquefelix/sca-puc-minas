using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCA.Gateway.Domain;
using SCA.Gateway.Repository;
using SCA.Gateway.Services;

namespace SCA.Gateway.Controllers
{
    [Route("v1/account")]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);
                                                                                                    
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = string.Empty;
            return new
            {
                user,
                token
            };
        }
    }
}
