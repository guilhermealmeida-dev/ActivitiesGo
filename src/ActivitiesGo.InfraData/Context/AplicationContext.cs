using System;
using ActivitiesGo.Domain.Entities;
using ActivitiesGo.InfraData.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesGo.InfraData.Context;

public class AplicationContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityType> ActivityTypes { get; set; }
    public DbSet<ActivityAddresse> ActivityAddresses { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<ActivityParticipant> ActivityParticipants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicationContext).Assembly);
        RelationshipConfiguration.Configure(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}

