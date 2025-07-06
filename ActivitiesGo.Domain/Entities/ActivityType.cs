using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class ActivityType : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public ICollection<Activity> Activities { get; set; }
}
