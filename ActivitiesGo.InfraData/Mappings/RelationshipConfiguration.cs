using System;
using System.Diagnostics.Metrics;
using ActivitiesGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesGo.InfraData.Mappings;

public class RelationshipConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        // User - Activity
        modelBuilder.Entity<User>()
        .HasMany(e => e.Activities)
        .WithOne(e => e.Creator)
        .HasPrincipalKey(e => e.Id)
        .HasForeignKey(e => e.CreatorId)
        .IsRequired();
        // User - Achievement
        modelBuilder.Entity<User>()
        .HasMany(e => e.Achievements)
        .WithMany(e => e.Users)
        .UsingEntity(e=>e.ToTable("UserAchievements"));
        // User - ActivityType
        modelBuilder.Entity<User>()
        .HasMany(e => e.Preferences)
        .WithMany(e => e.Users)
        .UsingEntity(e=>e.ToTable("Preferences"));
        //User - ActivityParticipant
        modelBuilder.Entity<User>()
        .HasMany(e => e.ActivitiesParticipated)
        .WithOne(e => e.User)
        .HasPrincipalKey(e => e.Id)
        .HasForeignKey(e => e.UserId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        //Activity - ActivityAddresse
        modelBuilder.Entity<Activity>()
        .HasOne(e => e.Addresse)
        .WithOne(e => e.Activity)
        .HasPrincipalKey<Activity>(e=>e.Id)
        .HasForeignKey<ActivityAddresse>(e=>e.ActivityId);
        //Activity - ActivityParticipant
        modelBuilder.Entity<Activity>()
        .HasMany(e => e.Participants)
        .WithOne(e => e.Activity)
        .HasPrincipalKey(e => e.Id)
        .HasForeignKey(e => e.ActivityId)
        .OnDelete(DeleteBehavior.Restrict);
        //Activity - ActivityType
        modelBuilder.Entity<Activity>()
        .HasOne(e => e.Type)
        .WithMany(e => e.Activities)
        .HasPrincipalKey(e => e.Id)
        .HasForeignKey(e=>e.TypeId);
    }
}
