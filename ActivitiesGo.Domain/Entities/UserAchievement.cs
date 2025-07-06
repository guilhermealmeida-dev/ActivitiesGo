using System;

namespace ActivitiesGo.Domain.Entities;

public class UserAchievement
{
    public Guid Id { get; set; }
    public Guid AchievementsId { get; set; }
    public Guid UserId { get; set; }
}
