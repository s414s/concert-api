﻿// <auto-generated />
using System;
using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("OnlyAdults")
                        .HasColumnType("boolean");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Capacity = 100,
                            Date = new DateTime(2024, 5, 17, 15, 41, 19, 560, DateTimeKind.Utc).AddTicks(2513),
                            Name = "boston",
                            OnlyAdults = false,
                            ZipCode = "50018"
                        },
                        new
                        {
                            Id = 2L,
                            Capacity = 200,
                            Date = new DateTime(2024, 5, 17, 15, 41, 19, 560, DateTimeKind.Utc).AddTicks(2515),
                            Name = "altamira",
                            OnlyAdults = false,
                            ZipCode = "28850"
                        });
                });

            modelBuilder.Entity("Domain.Entities.EventGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("GroupId");

                    b.ToTable("EventGroups");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EventId = 1L,
                            GroupId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            EventId = 1L,
                            GroupId = 2L
                        });
                });

            modelBuilder.Entity("Domain.Entities.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("ExplicitContent")
                        .HasColumnType("boolean");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedOn = new DateTime(2024, 5, 17, 15, 41, 19, 560, DateTimeKind.Utc).AddTicks(2368),
                            ExplicitContent = true,
                            Genre = "Rock",
                            Name = "Los Ramones",
                            Password = "root"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedOn = new DateTime(2024, 5, 17, 15, 41, 19, 560, DateTimeKind.Utc).AddTicks(2371),
                            ExplicitContent = true,
                            Genre = "Rock",
                            Name = "ACDC",
                            Password = "root"
                        });
                });

            modelBuilder.Entity("Domain.Entities.EventGroup", b =>
                {
                    b.HasOne("Domain.Entities.Event", "Event")
                        .WithMany("EventGroups")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Group", "Group")
                        .WithMany("EventGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Navigation("EventGroups");
                });

            modelBuilder.Entity("Domain.Entities.Group", b =>
                {
                    b.Navigation("EventGroups");
                });
#pragma warning restore 612, 618
        }
    }
}