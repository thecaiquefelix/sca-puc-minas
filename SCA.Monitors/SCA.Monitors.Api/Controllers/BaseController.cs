using System;
using Microsoft.AspNetCore.Mvc;
using SCA.Monitors.Domain.Entities;

namespace SCA.Monitors.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected new IActionResult Response(Result result)
        {
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Error);
        }

        protected new IActionResult Response<T>(Result<T> result)
        {
            if (result.Success)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Error);
        }

    }
}
