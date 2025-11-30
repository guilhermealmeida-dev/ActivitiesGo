using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivitiesGo.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async  Task<IActionResult> GetAsync()
        {
            return Ok("Dados do usuario");
        }
    }
}