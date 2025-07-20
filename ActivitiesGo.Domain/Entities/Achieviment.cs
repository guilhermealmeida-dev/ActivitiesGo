using System;
using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class Achievement : EntityBase
{
    public required string Name { get; set; }
    public required string Criterion { get; set; }
    
    public ICollection<User> Users { get; set; } = [];
}
