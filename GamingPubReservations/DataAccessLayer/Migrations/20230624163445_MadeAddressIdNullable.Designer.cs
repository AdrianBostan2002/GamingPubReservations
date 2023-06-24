﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230624163445_MadeAddressIdNullable")]
    partial class MadeAddressIdNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccessLayer.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.DaySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SpecialDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DaySchedule");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.GamingPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("GamingPlatforms");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.GamingPub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("GamingPubs");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.GamingPubGamingPlatform", b =>
                {
                    b.Property<int>("GamingPubId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("GamingPlatformId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("GamingPubId", "GamingPlatformId");

                    b.HasIndex("GamingPlatformId");

                    b.ToTable("GamingPubGamingPlatforms");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GamingPlatformId")
                        .HasColumnType("int");

                    b.Property<int>("GamingPubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamingPlatformId");

                    b.HasIndex("GamingPubId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DayScheduleGamingPub", b =>
                {
                    b.Property<int>("GamingPubsId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("GamingPubsId", "ScheduleId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("DayScheduleGamingPub");
                });

            modelBuilder.Entity("GamingPlatformGamingPub", b =>
                {
                    b.Property<int>("GamingPlatformsId")
                        .HasColumnType("int");

                    b.Property<int>("GamingPubsId")
                        .HasColumnType("int");

                    b.HasKey("GamingPlatformsId", "GamingPubsId");

                    b.HasIndex("GamingPubsId");

                    b.ToTable("GamingPlatformGamingPub");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.GamingPub", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.GamingPubGamingPlatform", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.GamingPlatform", "GamingPlatform")
                        .WithMany()
                        .HasForeignKey("GamingPlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.GamingPub", "GamingPub")
                        .WithMany()
                        .HasForeignKey("GamingPubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamingPlatform");

                    b.Navigation("GamingPub");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Reservation", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.GamingPlatform", "GamingPlatform")
                        .WithMany("Reservations")
                        .HasForeignKey("GamingPlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.GamingPub", "GamingPub")
                        .WithMany("Reservations")
                        .HasForeignKey("GamingPubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamingPlatform");

                    b.Navigation("GamingPub");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.User", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DayScheduleGamingPub", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.GamingPub", null)
                        .WithMany()
                        .HasForeignKey("GamingPubsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.DaySchedule", null)
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingPlatformGamingPub", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.GamingPlatform", null)
                        .WithMany()
                        .HasForeignKey("GamingPlatformsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.GamingPub", null)
                        .WithMany()
                        .HasForeignKey("GamingPubsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Entities.GamingPlatform", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.GamingPub", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
