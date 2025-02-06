﻿namespace UserApp_SingnalR.DataAcces.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserApp_SingnalR.Domain.Entities;

public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("user_roles");
        builder.HasKey(role => role.Id);

        builder.Property(role => role.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasData(
            new UserRole { Id = 1, Name = "Admin" },
            new UserRole { Id = 2, Name = "User" },
            new UserRole { Id = 3, Name = "Guest" }
        );
    }
}