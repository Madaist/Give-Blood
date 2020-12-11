﻿// <auto-generated />
using System;
using Give_Blood.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Give_Blood.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201211211722_Added_badge_points")]
    partial class Added_badge_points
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Give_Blood.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeagueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("NrOfPoints")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Give_Blood.Models.Badge", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrOfPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Badges");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Icon = "https://i.ibb.co/sR1DLrn/first-donation.png",
                            Name = "FIRST_DONATION",
                            NrOfPoints = 20
                        },
                        new
                        {
                            Id = "2",
                            Icon = "https://i.ibb.co/n0g1vd6/donation-long-time.png",
                            Name = "DONATION_AFTER_LONG_TIME",
                            NrOfPoints = 5
                        },
                        new
                        {
                            Id = "3",
                            Icon = "https://i.ibb.co/CzCdhfC/three-months.png",
                            Name = "DONATION_AFTER_3_MONTHS",
                            NrOfPoints = 40
                        },
                        new
                        {
                            Id = "4",
                            Icon = "https://i.ibb.co/qWNvzRx/holiday-donation1.png",
                            Name = "HOLIDAY_DONATION",
                            NrOfPoints = 50
                        },
                        new
                        {
                            Id = "5",
                            Icon = "https://i.ibb.co/QkPq2R9/covid-donation.png",
                            Name = "COVID_PLASMA_DONATION",
                            NrOfPoints = 30
                        },
                        new
                        {
                            Id = "6",
                            Icon = "https://i.ibb.co/5hrRy80/special-badge.png",
                            Name = "FIRST_SPECIAL_DONATION",
                            NrOfPoints = 35
                        },
                        new
                        {
                            Id = "7",
                            Icon = "https://i.ibb.co/SJW0h2j/three-nine.png",
                            Name = "3_DONATIONS_IN_9_MONTHS",
                            NrOfPoints = 60
                        });
                });

            modelBuilder.Entity("Give_Blood.Models.Donation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Type");

                    b.HasIndex("UserId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("Give_Blood.Models.DonationInfo", b =>
                {
                    b.Property<string>("DonationType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NrOfPeopleHelped")
                        .HasColumnType("int");

                    b.Property<int>("NrOfPoints")
                        .HasColumnType("int");

                    b.HasKey("DonationType");

                    b.ToTable("DonationInfo");

                    b.HasData(
                        new
                        {
                            DonationType = "ORDINARY_DONATION",
                            NrOfPeopleHelped = 3,
                            NrOfPoints = 20
                        },
                        new
                        {
                            DonationType = "SPECIAL_DONATION",
                            NrOfPeopleHelped = 1,
                            NrOfPoints = 25
                        },
                        new
                        {
                            DonationType = "COVID_PLASMA",
                            NrOfPeopleHelped = 3,
                            NrOfPoints = 35
                        });
                });

            modelBuilder.Entity("Give_Blood.Models.League", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxPoints")
                        .HasColumnType("int");

                    b.Property<int>("MinPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Icon = "https://i.ibb.co/x2XhmKb/Badge-Bronze-Blank.png",
                            MaxPoints = 35,
                            MinPoints = 0,
                            Name = "Bronze"
                        },
                        new
                        {
                            Id = "2",
                            Icon = "https://i.ibb.co/N1WvGS7/Badge-Silver-Blank.png",
                            MaxPoints = 70,
                            MinPoints = 36,
                            Name = "Silver"
                        },
                        new
                        {
                            Id = "3",
                            Icon = "https://i.ibb.co/ZKkccn9/Badge-Gold-Blank.png",
                            MaxPoints = 120,
                            MinPoints = 71,
                            Name = "Gold"
                        },
                        new
                        {
                            Id = "4",
                            Icon = "https://i.ibb.co/vYB15Vr/Badge-Sapphire-Blank.png",
                            MaxPoints = 160,
                            MinPoints = 121,
                            Name = "Sapphire"
                        },
                        new
                        {
                            Id = "5",
                            Icon = "https://i.ibb.co/h1LK5dT/Badge-Ruby-Blank.png",
                            MaxPoints = 200,
                            MinPoints = 161,
                            Name = "Ruby"
                        },
                        new
                        {
                            Id = "6",
                            Icon = "https://i.ibb.co/cLtG5RC/Badge-Amethyst-Blank.png",
                            MaxPoints = 250,
                            MinPoints = 201,
                            Name = "Amethyst"
                        },
                        new
                        {
                            Id = "7",
                            Icon = "https://i.ibb.co/jMRMtRV/Badge-Pearl-Blank.png",
                            MaxPoints = 290,
                            MinPoints = 251,
                            Name = "Pearl"
                        },
                        new
                        {
                            Id = "8",
                            Icon = "https://i.ibb.co/kBdQq6p/Badge-Obsidian-Blank.png",
                            MaxPoints = 400,
                            MinPoints = 291,
                            Name = "Obsidian"
                        },
                        new
                        {
                            Id = "9",
                            Icon = "https://i.ibb.co/DMRB8k9/Badge-Diamond-Blank.png",
                            MaxPoints = 10000,
                            MinPoints = 401,
                            Name = "Diamond"
                        });
                });

            modelBuilder.Entity("Give_Blood.Models.UserBadges", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BadgeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BadgeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBadges");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(50000);

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(50000);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Key");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.ToTable("PersistedGrants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Give_Blood.Models.ApplicationUser", b =>
                {
                    b.HasOne("Give_Blood.Models.League", "League")
                        .WithMany("Users")
                        .HasForeignKey("LeagueId");
                });

            modelBuilder.Entity("Give_Blood.Models.Donation", b =>
                {
                    b.HasOne("Give_Blood.Models.DonationInfo", "DonationInfo")
                        .WithMany("Donations")
                        .HasForeignKey("Type");

                    b.HasOne("Give_Blood.Models.ApplicationUser", "User")
                        .WithMany("Donations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Give_Blood.Models.UserBadges", b =>
                {
                    b.HasOne("Give_Blood.Models.Badge", "Badge")
                        .WithMany("UserBadges")
                        .HasForeignKey("BadgeId");

                    b.HasOne("Give_Blood.Models.ApplicationUser", "User")
                        .WithMany("UserBadges")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Give_Blood.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Give_Blood.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Give_Blood.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Give_Blood.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
