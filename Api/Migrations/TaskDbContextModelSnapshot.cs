﻿// <auto-generated />
using DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Presentation.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    partial class TaskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("Presentation.Data.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "I failed to import file",
                            DueDate = new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "To Do",
                            Title = "File Import"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Results are now available",
                            DueDate = new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "To Do",
                            Title = "Race Results"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Please import running series data",
                            DueDate = new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "To Do",
                            Title = "Running Series"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
