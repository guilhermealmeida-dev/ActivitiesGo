using System;
using ActivitiesGo.Aplication.DTOs.Achievement;

namespace ActivitiesGo.Aplication.DTOs.User;

public class LoginResponseDto
{
    public string? Token { get; set; }
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CPF { get; set; }
    public string? Avatar { get; set; }
    public int XP { get; set; }
    public int Level { get; set; }
    public ICollection<AchievementDto> Achievements { get; set; } = [];
}


