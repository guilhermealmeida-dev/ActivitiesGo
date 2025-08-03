using System;
using ActivitiesGo.Aplication.DTOs.Auth;
using ActivitiesGo.Aplication.DTOs.User;

namespace ActivitiesGo.Aplication.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterUserDto userDto);
    Task<UserResponseDto> LoginAsync(LoginDto loginDto);
}
