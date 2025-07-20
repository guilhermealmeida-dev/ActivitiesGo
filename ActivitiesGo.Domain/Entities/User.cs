using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class User : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string CPF { get; set; }
    public required string Password { get; set; }
    public string? Avatar { get; set; }
    public int XP { get; set; }
    public int Level { get; set; }
    public DateTime? DeleteAt { get; set; }

    public ICollection<Achievement> Achievements { get; set; } = [];
    public ICollection<Activity> Activities { get; set; } = [];
    public ICollection<ActivityType> Preferences { get; set; } = [];
    public ICollection<ActivityParticipant> ActivitiesParticipated { get; set; } = [];

}
