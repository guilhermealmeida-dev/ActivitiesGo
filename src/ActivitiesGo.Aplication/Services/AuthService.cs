using System;
using System.Net;
using ActivitiesGo.Aplication.DTOs.Achievement;
using ActivitiesGo.Aplication.DTOs.Auth;
using ActivitiesGo.Aplication.DTOs.User;
using ActivitiesGo.Aplication.Interfaces;
using ActivitiesGo.Domain.Entities;
using ActivitiesGo.Domain.Interfaces;
using ActivitiesGo.Shared.Config;
using ActivitiesGo.Shared.Exceptions;
using Microsoft.Extensions.Options;

namespace ActivitiesGo.Aplication.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly string _baseUrl;
    private readonly IJwtTokenService _jwtTokenService;


    public AuthService(IUserRepository userRepository, IOptions<AppSettings> options, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _baseUrl = options.Value.BaseUrlApi;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
    {
        var userDb = await _userRepository.FindByEmailAsync(loginDto.Email)
        ?? throw new NotFoundExeption("Usuárion não encontrado.");

        if (userDb.DeleteAt != null)
            throw new InactiveAccount();

        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, userDb.Password))
            throw new AppException("Senha incorreta.", HttpStatusCode.Unauthorized);

        var token = _jwtTokenService.GenerateToken(userDb);

        LoginResponseDto LoginResponseData = new()
        {
            Token = token,
            Name = userDb.Name,
            Email = userDb.Email,
            CPF = userDb.CPF,
            Avatar = userDb.Avatar,
            XP = userDb.XP,
            Level = userDb.Level,
            Achievements = [.. userDb.Achievements.Select(e => new AchievementDto
            {
                Name = e.Name,
                Criterion = e.Criterion
            })]
        };

        return LoginResponseData;
    }

    public async Task RegisterAsync(RegisterUserDto userDto)
    {
        var exeption = new AppException("O e-mail ou CPF informado já pertence a outro usuário", HttpStatusCode.Conflict);

        var existingByEmail = _userRepository.FindByEmailAsync(userDto.Email);
        if (existingByEmail is not null) throw exeption;

        var existingByCpf = _userRepository.FindByCPFAsync(userDto.CPF);
        if (existingByCpf is not null) throw exeption;

        User user = new()
        {
            Name = userDto.Name,
            Email = userDto.Email,
            CPF = userDto.CPF,
            Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            Avatar = _baseUrl + "/images/profile.png",
            CreatedAt = DateTime.Now
        };

        await _userRepository.CreateAsync(user);
    }
}
