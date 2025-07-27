using System;
using ActivitiesGo.Domain.Entities.Base;

namespace ActivitiesGo.Domain.Entities;

public class ActivityAddresse : EntityBase
{
    public required double Latitude { get; set; }
    public required double Longitude { get; set; }

    public required Guid ActivityId { get; set; }

    public required Activity Activity { get; set; }
}
