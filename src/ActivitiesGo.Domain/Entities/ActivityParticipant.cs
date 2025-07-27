using System;
using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class ActivityParticipant : EntityBase
{
    public bool Apreved { get; set; }
    public DateTime ConfirmedAt { get; set; }

    public required Guid ActivityId { get; set; }
    public required Guid UserId { get; set; }

    public required User User { get; set; }
    public required Activity Activity { get; set; }
}
