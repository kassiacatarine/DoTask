using DoTask.Domain.AggregatesModel.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoTask.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", schema: "dbo");
            builder.HasKey(t => t.Id).HasName("id");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(t => t.Name).HasColumnName("name").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Email).HasColumnName("email").HasMaxLength(200).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(p => p.Password).HasColumnName("password").IsRequired();

            builder.Property(p => p.Removed).HasColumnName("removed");
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
