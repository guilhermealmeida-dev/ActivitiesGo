using ActivitiesGo.Aplication.DTOs.User;
using ActivitiesGo.Aplication.Interfaces;
using ActivitiesGo.Shared.Exceptions;
using ActivitiesGo.Shared.Utils;
using Microsoft.AspNetCore.Mvc;
namespace ActivitiesGo.API.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ValidationUtils.GetModelErrors(ModelState);

                throw new ValidationException(errors);
            }

            await _authService.RegisterAsync(dto);

            return Ok(new
            {
                mensage = "Usuario cadastrado com sucesso!"
            });
        }
    }
}
