using System;

namespace ActivitiesGo.Domain.Entities.Base;

public class EntityBase : IEntityBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
