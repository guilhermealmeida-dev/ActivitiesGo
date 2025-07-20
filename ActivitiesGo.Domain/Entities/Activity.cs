using System;
using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class Activity : EntityBase
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ConfirmationCode { get; set; }
    public string? Image { get; set; }
    public required DateTime SheduleDate { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public bool Private { get; set; }

    public required Guid CreatorId { get; set; }
    public required Guid TypeId { get; set; }
    public required Guid AddresseId { get; set; }

    public required User Creator { get; set; }
    public required ActivityType Type { get; set; }
    public required ActivityAddresse Addresse { get; set; }
    public ICollection<ActivityParticipant>? Participants { get; set; }

}
