﻿// <auto-generated />
using System;
using BroadageSports.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BroadagaSports.API.Migrations
{
    [DbContext(typeof(BroadageSportsContext))]
    [Migration("20210717195131_ft6")]
    partial class ft6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BroadageSports.Entity.Entities.AwayTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("MediumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScoreId")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.HasIndex("ScoreId")
                        .IsUnique();

                    b.ToTable("AwayTeams");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.HomeTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("MediumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScoreId")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.HasIndex("ScoreId")
                        .IsUnique();

                    b.ToTable("HomeTeams");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentMinute")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MatchGlobalId")
                        .HasColumnType("int");

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("Stoppage")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoundId")
                        .IsUnique();

                    b.HasIndex("StageId")
                        .IsUnique();

                    b.HasIndex("StatusId")
                        .IsUnique();

                    b.HasIndex("TournamentId")
                        .IsUnique();

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Current")
                        .HasColumnType("int");

                    b.Property<int>("ExtraTime")
                        .HasColumnType("int");

                    b.Property<int>("HalfTime")
                        .HasColumnType("int");

                    b.Property<int>("Penalties")
                        .HasColumnType("int");

                    b.Property<int>("Regular")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.AwayTeam", b =>
                {
                    b.HasOne("BroadageSports.Entity.Entities.Match", "Match")
                        .WithOne("AwayTeam")
                        .HasForeignKey("BroadageSports.Entity.Entities.AwayTeam", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BroadageSports.Entity.Entities.Score", "Score")
                        .WithOne("AwayTeam")
                        .HasForeignKey("BroadageSports.Entity.Entities.AwayTeam", "ScoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Score");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.HomeTeam", b =>
                {
                    b.HasOne("BroadageSports.Entity.Entities.Match", "Match")
                        .WithOne("HomeTeam")
                        .HasForeignKey("BroadageSports.Entity.Entities.HomeTeam", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BroadageSports.Entity.Entities.Score", "Score")
                        .WithOne("HomeTeam")
                        .HasForeignKey("BroadageSports.Entity.Entities.HomeTeam", "ScoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Score");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Match", b =>
                {
                    b.HasOne("BroadageSports.Entity.Entities.Round", "Round")
                        .WithOne("Match")
                        .HasForeignKey("BroadageSports.Entity.Entities.Match", "RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BroadageSports.Entity.Entities.Stage", "Stage")
                        .WithOne("Match")
                        .HasForeignKey("BroadageSports.Entity.Entities.Match", "StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BroadageSports.Entity.Entities.Status", "Status")
                        .WithOne("Match")
                        .HasForeignKey("BroadageSports.Entity.Entities.Match", "StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BroadageSports.Entity.Entities.Tournament", "Tournament")
                        .WithOne("Match")
                        .HasForeignKey("BroadageSports.Entity.Entities.Match", "TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Round");

                    b.Navigation("Stage");

                    b.Navigation("Status");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Match", b =>
                {
                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Round", b =>
                {
                    b.Navigation("Match");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Score", b =>
                {
                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Stage", b =>
                {
                    b.Navigation("Match");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Status", b =>
                {
                    b.Navigation("Match");
                });

            modelBuilder.Entity("BroadageSports.Entity.Entities.Tournament", b =>
                {
                    b.Navigation("Match");
                });
#pragma warning restore 612, 618
        }
    }
}