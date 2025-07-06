using System;
using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class ActivityAddresse : EntityBase
{
    public Guid ActivityId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
