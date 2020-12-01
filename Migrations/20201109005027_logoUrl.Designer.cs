﻿// <auto-generated />
using System;
using Job_Management_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Job_Management_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201109005027_logoUrl")]
    partial class logoUrl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Job_Management_API.Models.Company", b =>
                {
                    b.Property<Guid>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Job_Management_API.Models.Jobs", b =>
                {
                    b.Property<Guid>("jobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("companyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("jobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("jobStatus")
                        .HasColumnType("bit");

                    b.HasKey("jobId");

                    b.HasIndex("companyId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Job_Management_API.Models.Workers", b =>
                {
                    b.Property<Guid>("workerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("workerId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Job_Management_API.Models.WorkersJobs", b =>
                {
                    b.Property<Guid>("workersJobsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("jobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("workerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("workersJobsId");

                    b.HasIndex("jobId");

                    b.HasIndex("workerId");

                    b.ToTable("WorkersJobs");
                });

            modelBuilder.Entity("Job_Management_API.Models.Jobs", b =>
                {
                    b.HasOne("Job_Management_API.Models.Company", "company")
                        .WithMany("jobs")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Job_Management_API.Models.WorkersJobs", b =>
                {
                    b.HasOne("Job_Management_API.Models.Jobs", "job")
                        .WithMany("workersJobs")
                        .HasForeignKey("jobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_Management_API.Models.Workers", "worker")
                        .WithMany("workersJobs")
                        .HasForeignKey("workerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
