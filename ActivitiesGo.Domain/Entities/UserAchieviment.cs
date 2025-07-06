using System;
using System.Reflection.Metadata;

namespace ActivitiesGo.Domain.Entities;

public class UserAchievement
{
    public Guid Id { get; set; }
    public Guid AchievementsId { get; set; }
    public Guid UserId { get; set; }

    public User User { get; set; }
    public Achievement Achievement { get; set; }
}
