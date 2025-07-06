using System;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesGo.InfraData.Context;

public class AplicationContext : DbContext
{
    public AplicationContext(DbContextOptions options) : base(options)
    {

    }
}
