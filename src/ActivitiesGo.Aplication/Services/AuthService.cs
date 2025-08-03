using System;
using System.Net;
using ActivitiesGo.Aplication.DTOs.Auth;
using ActivitiesGo.Aplication.DTOs.User;
using ActivitiesGo.Aplication.Interfaces;
using ActivitiesGo.Domain.Entities;
using ActivitiesGo.Domain.Interfaces;
using ActivitiesGo.Shared.Exceptions;

namespace ActivitiesGo.Aplication.Services;

public class AuthService(IUserRepository userRepository) : IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;

    public Task<UserResponseDto> LoginAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public async Task RegisterAsync(RegisterUserDto userDto)
    {
        if (_userRepository.FindByEmail(userDto.Email) is not null && _userRepository.FindByEmail(userDto.CPF) is not null)
            throw new AppException("Email ou Cpf informado já pertence a outro usuário", HttpStatusCode.Conflict);

        User user = new()
        {
            Name = userDto.Name,
            Email = userDto.Email,
            CPF = userDto.CPF,
            Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            CreatedAt = DateTime.Now
        };

        await _userRepository.CreateAsync(user);
    }
}
