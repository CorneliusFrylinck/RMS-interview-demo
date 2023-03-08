﻿// <auto-generated />
using System;
using CanidateApp.Server.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CanidateApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("CanidateApp.Shared.SiteAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contractor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SiteAssignments");
                });

            modelBuilder.Entity("CanidateApp.Shared.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReasonId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TicketCreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TicketResolvedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReasonId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CanidateApp.Shared.TicketReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Reason")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TicketReasons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Reason = 1,
                            Title = "Tower connection is failing"
                        },
                        new
                        {
                            Id = 2,
                            Reason = 2,
                            Title = "Tower has trouble lasting through 4-hour loadshedding"
                        },
                        new
                        {
                            Id = 3,
                            Reason = 3,
                            Title = "Tower has trouble lasting through 2-hour loadshedding"
                        },
                        new
                        {
                            Id = 4,
                            Reason = 4,
                            Title = "Tower connection is slow"
                        },
                        new
                        {
                            Id = 5,
                            Reason = 5,
                            Title = "Tower connection is unstable"
                        },
                        new
                        {
                            Id = 6,
                            Reason = 6,
                            Title = "Other"
                        });
                });

            modelBuilder.Entity("CanidateApp.Shared.Ticket", b =>
                {
                    b.HasOne("CanidateApp.Shared.TicketReason", "Reason")
                        .WithMany()
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reason");
                });
#pragma warning restore 612, 618
        }
    }
}
