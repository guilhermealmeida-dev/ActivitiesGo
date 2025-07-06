using System;
using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class Achievement : EntityBase
{
    public string Name { get; set; }
    public string Criterion { get; set; }
    public ICollection<UserAchievement> Users { get; set; }

}
