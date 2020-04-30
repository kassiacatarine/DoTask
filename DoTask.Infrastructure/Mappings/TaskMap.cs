using DoTask.Domain.AggregatesModel.Tasks;
using DoTask.Domain.AggregatesModel.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoTask.Infrastructure.Mappings
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("tasks", schema: "dbo");
            builder.HasKey(t => t.Id).HasName("id");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(t => t.Description).HasColumnName("description").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Concluded).HasColumnName("concluded").HasDefaultValue(false).IsRequired();

            builder.Property(p => p.UserId).HasColumnName("id_user").IsRequired();

            builder.Property(p => p.Removed).HasColumnName("removed");
            builder.HasQueryFilter(p => !p.Removed);

            builder.HasOne<User>()
                .WithMany(u => u.Tasks)
                .IsRequired(false)
                .HasForeignKey("id_user");
        }
    }
}
