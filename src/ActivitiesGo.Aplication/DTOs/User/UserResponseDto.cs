using System;
using ActivitiesGo.Aplication.DTOs.Achievement;

namespace ActivitiesGo.Aplication.DTOs.User;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string CPF { get; set; }
    public required string Password { get; set; }
    public ICollection<AchievementDto> Achievements { get; set; } = [];
}


