using System;
using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class Activity:EntityBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid TypeId { get; set; }
    public string ConfirmationCode { get; set; }
    public string Image { get; set; }
    public DateTime SheduleDate { get; set; }
    public DateTime DeletedAt { get; set; }
    public DateTime CompletedAt { get; set; }
    public bool Private { get; set; }
    public Guid CreatorId { get; set; }

}
