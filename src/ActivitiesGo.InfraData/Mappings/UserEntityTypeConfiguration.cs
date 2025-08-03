using System;
using ActivitiesGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivitiesGo.InfraData.Mappings;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(e => e.Email)
        .IsUnique()
        .HasDatabaseName("IX_User_Email");;

        builder.HasIndex(e => e.CPF)
        .IsUnique()
        .HasDatabaseName("IX_User_CPF");
    }
}
