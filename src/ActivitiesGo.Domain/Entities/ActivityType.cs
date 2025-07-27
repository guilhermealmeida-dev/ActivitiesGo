using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class ActivityType : EntityBase
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }

    public ICollection<Activity> Activities { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
}
