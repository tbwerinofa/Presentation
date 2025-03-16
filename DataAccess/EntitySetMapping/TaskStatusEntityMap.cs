using DataAccess.Core;
using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntitySetMapping;

public partial class TaskStatusEntityMap : InsightEntityTypeConfiguration<TaskStatusEntity>
    {
        public TaskStatusEntityMap(){}

        public override void Configure(EntityTypeBuilder<TaskStatusEntity> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);
            modelBuilder.Property(a => a.Name).IsRequired();
            modelBuilder.HasIndex(a => a.Name).IsUnique();
            modelBuilder.Property(a => a.Name).HasMaxLength(100);
        }
    }

