﻿// <auto-generated />
using System;
using DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Presentation.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    [Migration("20250317041756_UpdateConstraints")]
    partial class UpdateConstraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("DataAccess.EntitySet.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("TaskStatusEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TaskStatusEntityId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DataAccess.EntitySet.TaskStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaskStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "To Do"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("DataAccess.EntitySet.TaskEntity", b =>
                {
                    b.HasOne("DataAccess.EntitySet.TaskStatusEntity", "TaskStatusEntity")
                        .WithMany("TaskEntities")
                        .HasForeignKey("TaskStatusEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskStatusEntity");
                });

            modelBuilder.Entity("DataAccess.EntitySet.TaskStatusEntity", b =>
                {
                    b.Navigation("TaskEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
