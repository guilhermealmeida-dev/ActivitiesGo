using System;

namespace ActivitiesGo.Domain.Entities;

public class Preference
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public Guid TypeId { get; set; }

}
