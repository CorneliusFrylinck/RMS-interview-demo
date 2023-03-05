﻿// <auto-generated />
using System;
using CanidateApp.Server.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CanidateApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230305142513_AddedTicketReasonSeedData")]
    partial class AddedTicketReasonSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("CanidateApp.Shared.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReasonId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("TEXT");

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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TicketReasons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Tower connection is failing."
                        },
                        new
                        {
                            Id = 2,
                            Title = "Tower has trouble lasting through 4-hour loadshedding."
                        },
                        new
                        {
                            Id = 3,
                            Title = "Tower has trouble lasting through 2-hour loadshedding."
                        },
                        new
                        {
                            Id = 4,
                            Title = "Tower connection is slow."
                        },
                        new
                        {
                            Id = 5,
                            Title = "Tower connection is unstable."
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
