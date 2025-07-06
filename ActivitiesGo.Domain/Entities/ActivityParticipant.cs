using System;
using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class ActivityParticipant : EntityBase
{
    public Guid ActivityId { get; set; }
    public Guid UserId { get; set; }
    public bool Apreved { get; set; }
    public DateTime ConfirmedAt { get; set; }
    public User User { get; set; }
    public Activity Activity { get; set; }
}
