using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataAccess.EntitySet;
using DataAccess.Core;

namespace DataAccess.EntitySetMapping;

public partial class TaskEntityMap : InsightEntityTypeConfiguration<TaskEntity>
    {
        public TaskEntityMap()
        {


        }

        public override void Configure(EntityTypeBuilder<TaskEntity> modelBuilder)
        {

            modelBuilder.HasKey(c => c.Id);
 
            modelBuilder.Property(a => a.Title).HasMaxLength(100);
            modelBuilder.Property(a => a.Description).HasMaxLength(5000);
            modelBuilder.Property(a => a.Title).IsRequired();

            //modelBuilder
            //         .HasOne(u => u.Document)
            //         .WithMany(u => u.Trophies)
            //         .OnDelete(DeleteBehavior.Restrict);


        }
    }

