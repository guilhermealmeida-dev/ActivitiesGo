using ActivitiesGo.API.Utils;
using ActivitiesGo.Aplication.DTOs.Auth;
using ActivitiesGo.Aplication.DTOs.User;
using ActivitiesGo.Aplication.Interfaces;
using ActivitiesGo.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ActivitiesGo.API.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService, IJwtTokenService jwtTokenService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ValidationUtils.GetModelErrors(ModelState);

                throw new ValidationException(errors);
            }

            await _authService.RegisterAsync(dto);

            return Ok(new
            {
                mensage = "Usuario cadastrado com sucesso."
            });
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]

        public async Task<IActionResult> SignIn(LoginDto dto)
        {

            if (!ModelState.IsValid)
            {
                var errors = ValidationUtils.GetModelErrors(ModelState);

                throw new ValidationException(errors);
            }

            var data = await _authService.LoginAsync(dto);

            return Ok(data);
        }

    }
}
