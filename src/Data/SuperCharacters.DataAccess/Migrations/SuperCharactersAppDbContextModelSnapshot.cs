﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperCharacters.DataAccess;

namespace SuperCharacters.DataAccess.Migrations
{
    [DbContext(typeof(SuperCharactersAppDbContext))]
    partial class SuperCharactersAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SuperCharacters.Models.Character", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Armour");

                    b.Property<string>("CharacterType")
                        .IsRequired();

                    b.Property<int>("Damage");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("SecretIdentityId");

                    b.Property<string>("TeamId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SecretIdentityId")
                        .IsUnique()
                        .HasFilter("[SecretIdentityId] IS NOT NULL");

                    b.HasIndex("TeamId");

                    b.ToTable("Characters");

                    b.HasDiscriminator<string>("CharacterType").HasValue("Character");
                });

            modelBuilder.Entity("SuperCharacters.Models.Score", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CharacterScoreId");

                    b.Property<int>("Loses");

                    b.Property<string>("PlayerScoreId");

                    b.Property<string>("TeamScoreId");

                    b.Property<int>("Wins");

                    b.HasKey("Id");

                    b.HasIndex("CharacterScoreId")
                        .IsUnique()
                        .HasFilter("[CharacterScoreId] IS NOT NULL");

                    b.HasIndex("PlayerScoreId")
                        .IsUnique()
                        .HasFilter("[PlayerScoreId] IS NOT NULL");

                    b.HasIndex("TeamScoreId")
                        .IsUnique()
                        .HasFilter("[TeamScoreId] IS NOT NULL");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("SuperCharacters.Models.SecretIdentity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SecretIdentities");
                });

            modelBuilder.Entity("SuperCharacters.Models.SuperCharactersUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SuperCharacters.Models.SuperPower", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CharacterId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("SuperPowers");
                });

            modelBuilder.Entity("SuperCharacters.Models.Team", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SuperCharacters.Models.SuperHero", b =>
                {
                    b.HasBaseType("SuperCharacters.Models.Character");

                    b.Property<double>("HitPoints");

                    b.HasDiscriminator().HasValue("Superhero");
                });

            modelBuilder.Entity("SuperCharacters.Models.SuperVillain", b =>
                {
                    b.HasBaseType("SuperCharacters.Models.Character");

                    b.Property<int>("HitPoints")
                        .HasColumnName("SuperVillain_HitPoints");

                    b.HasDiscriminator().HasValue("Supervillain");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SuperCharacters.Models.SuperCharactersUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SuperCharacters.Models.SuperCharactersUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SuperCharacters.Models.SuperCharactersUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SuperCharacters.Models.SuperCharactersUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SuperCharacters.Models.Character", b =>
                {
                    b.HasOne("SuperCharacters.Models.SecretIdentity", "SecretIdentity")
                        .WithOne("Character")
                        .HasForeignKey("SuperCharacters.Models.Character", "SecretIdentityId");

                    b.HasOne("SuperCharacters.Models.Team", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SuperCharacters.Models.Score", b =>
                {
                    b.HasOne("SuperCharacters.Models.Character", "CharacterScore")
                        .WithOne("Score")
                        .HasForeignKey("SuperCharacters.Models.Score", "CharacterScoreId");

                    b.HasOne("SuperCharacters.Models.SuperCharactersUser", "PlayerScore")
                        .WithOne("Score")
                        .HasForeignKey("SuperCharacters.Models.Score", "PlayerScoreId");

                    b.HasOne("SuperCharacters.Models.Team", "TeamScore")
                        .WithOne("Score")
                        .HasForeignKey("SuperCharacters.Models.Score", "TeamScoreId");
                });

            modelBuilder.Entity("SuperCharacters.Models.SuperPower", b =>
                {
                    b.HasOne("SuperCharacters.Models.Character")
                        .WithMany("SuperPowers")
                        .HasForeignKey("CharacterId");
                });
#pragma warning restore 612, 618
        }
    }
}
