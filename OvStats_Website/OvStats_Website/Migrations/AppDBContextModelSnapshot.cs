﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OvStats_Website.DBContext;

#nullable disable

namespace OvStats_Website.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OvStats_Website.DTO.InfoDTO", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("GameId"));

                    b.Property<long>("GameCreation")
                        .HasColumnType("bigint");

                    b.Property<long>("GameDuration")
                        .HasColumnType("bigint");

                    b.Property<long>("GameEndTimestamp")
                        .HasColumnType("bigint");

                    b.Property<string>("GameMode")
                        .HasColumnType("text");

                    b.Property<string>("GameName")
                        .HasColumnType("text");

                    b.Property<long>("GameStartTimestamp")
                        .HasColumnType("bigint");

                    b.Property<string>("GameType")
                        .HasColumnType("text");

                    b.Property<string>("GameVersion")
                        .HasColumnType("text");

                    b.Property<int>("MapId")
                        .HasColumnType("integer");

                    b.Property<string>("PlatformId")
                        .HasColumnType("text");

                    b.Property<int>("QueueId")
                        .HasColumnType("integer");

                    b.Property<string>("TournamentCode")
                        .HasColumnType("text");

                    b.HasKey("GameId");

                    b.ToTable("InfoDTO");
                });

            modelBuilder.Entity("OvStats_Website.DTO.MatchDTO", b =>
                {
                    b.Property<string>("MatchId")
                        .HasColumnType("text");

                    b.Property<long?>("InfoGameId")
                        .HasColumnType("bigint");

                    b.Property<int?>("MetaDataId")
                        .HasColumnType("integer");

                    b.HasKey("MatchId");

                    b.HasIndex("InfoGameId");

                    b.HasIndex("MetaDataId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("OvStats_Website.DTO.MetaDataDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DataVersion")
                        .HasColumnType("text");

                    b.Property<string>("MatchID")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MetaDataDTO");
                });

            modelBuilder.Entity("OvStats_Website.DTO.MiniSeries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Losses")
                        .HasColumnType("integer");

                    b.Property<string>("Progress")
                        .HasColumnType("text");

                    b.Property<int>("Target")
                        .HasColumnType("integer");

                    b.Property<int>("Wins")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MiniSeries");
                });

            modelBuilder.Entity("OvStats_Website.DTO.ParticipantsDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Assists")
                        .HasColumnType("integer");

                    b.Property<int>("BaronKills")
                        .HasColumnType("integer");

                    b.Property<int>("BountyKills")
                        .HasColumnType("integer");

                    b.Property<int>("ChampExperience")
                        .HasColumnType("integer");

                    b.Property<int>("ChampLevel")
                        .HasColumnType("integer");

                    b.Property<int>("ChampionId")
                        .HasColumnType("integer");

                    b.Property<string>("ChampionName")
                        .HasColumnType("text");

                    b.Property<int>("ChampionTransform")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumablesPurchased")
                        .HasColumnType("integer");

                    b.Property<int>("DamageDealtToBuildings")
                        .HasColumnType("integer");

                    b.Property<int>("DamageDealtToObjectives")
                        .HasColumnType("integer");

                    b.Property<int>("DamageDealtToTurrets")
                        .HasColumnType("integer");

                    b.Property<int>("DamageSelfMitigated")
                        .HasColumnType("integer");

                    b.Property<int>("Deaths")
                        .HasColumnType("integer");

                    b.Property<int>("DetectorWardsPlaced")
                        .HasColumnType("integer");

                    b.Property<int>("DoubleKills")
                        .HasColumnType("integer");

                    b.Property<int>("DragonKills")
                        .HasColumnType("integer");

                    b.Property<bool>("FirstBloodAssist")
                        .HasColumnType("boolean");

                    b.Property<bool>("FirstBloodKill")
                        .HasColumnType("boolean");

                    b.Property<bool>("FirstTowerAssist")
                        .HasColumnType("boolean");

                    b.Property<bool>("FirstTowerKill")
                        .HasColumnType("boolean");

                    b.Property<bool>("GameEndedInEarlySurrender")
                        .HasColumnType("boolean");

                    b.Property<int>("GoldEarned")
                        .HasColumnType("integer");

                    b.Property<int>("GoldSpent")
                        .HasColumnType("integer");

                    b.Property<string>("IndivdualPosition")
                        .HasColumnType("text");

                    b.Property<long>("InfoId")
                        .HasColumnType("bigint");

                    b.Property<int>("InhibitorKills")
                        .HasColumnType("integer");

                    b.Property<int>("InhibitorTakedowns")
                        .HasColumnType("integer");

                    b.Property<int>("InhibitorsLost")
                        .HasColumnType("integer");

                    b.Property<int>("Item0")
                        .HasColumnType("integer");

                    b.Property<int>("Item1")
                        .HasColumnType("integer");

                    b.Property<int>("Item2")
                        .HasColumnType("integer");

                    b.Property<int>("Item3")
                        .HasColumnType("integer");

                    b.Property<int>("Item4")
                        .HasColumnType("integer");

                    b.Property<int>("Item5")
                        .HasColumnType("integer");

                    b.Property<int>("Item6")
                        .HasColumnType("integer");

                    b.Property<int>("ItemsPurchased")
                        .HasColumnType("integer");

                    b.Property<int>("KillingSprees")
                        .HasColumnType("integer");

                    b.Property<int>("Kills")
                        .HasColumnType("integer");

                    b.Property<string>("Lane")
                        .HasColumnType("text");

                    b.Property<int>("LargestCriticalStrike")
                        .HasColumnType("integer");

                    b.Property<int>("LargestMultiKill")
                        .HasColumnType("integer");

                    b.Property<int>("LongestTimeSpentAlive")
                        .HasColumnType("integer");

                    b.Property<int>("MagicDamageDealt")
                        .HasColumnType("integer");

                    b.Property<int>("MagicDamageDealtToChampions")
                        .HasColumnType("integer");

                    b.Property<int>("MagicDamageTaken")
                        .HasColumnType("integer");

                    b.Property<int>("NeutralMinionsKilled")
                        .HasColumnType("integer");

                    b.Property<int>("NexusKills")
                        .HasColumnType("integer");

                    b.Property<int>("NexusLost")
                        .HasColumnType("integer");

                    b.Property<int>("NexusTakedowns")
                        .HasColumnType("integer");

                    b.Property<int>("ObjectivesStolen")
                        .HasColumnType("integer");

                    b.Property<int>("ObjectivesStolenAssists")
                        .HasColumnType("integer");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("integer");

                    b.Property<int>("PentaKills")
                        .HasColumnType("integer");

                    b.Property<int>("PhysicalDamageDealt")
                        .HasColumnType("integer");

                    b.Property<int>("PhysicalDamageDealtToChampions")
                        .HasColumnType("integer");

                    b.Property<int>("PhysicalDamageTaken")
                        .HasColumnType("integer");

                    b.Property<int>("ProfileIcon")
                        .HasColumnType("integer");

                    b.Property<string>("Puuid")
                        .HasColumnType("text");

                    b.Property<int>("QuadraKills")
                        .HasColumnType("integer");

                    b.Property<string>("RiotIdName")
                        .HasColumnType("text");

                    b.Property<string>("RiotIdTagline")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<int>("SightWardsBoughtInGame")
                        .HasColumnType("integer");

                    b.Property<int>("Spell1Casts")
                        .HasColumnType("integer");

                    b.Property<int>("Spell2Casts")
                        .HasColumnType("integer");

                    b.Property<int>("Spell3Casts")
                        .HasColumnType("integer");

                    b.Property<int>("Spell4Casts")
                        .HasColumnType("integer");

                    b.Property<int>("Summoner1Casts")
                        .HasColumnType("integer");

                    b.Property<int>("Summoner1Id")
                        .HasColumnType("integer");

                    b.Property<int>("Summoner2Casts")
                        .HasColumnType("integer");

                    b.Property<int>("Summoner2Id")
                        .HasColumnType("integer");

                    b.Property<string>("Summonerid")
                        .HasColumnType("text");

                    b.Property<bool>("TeamEarlySurrendered")
                        .HasColumnType("boolean");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.Property<string>("TeamPosition")
                        .HasColumnType("text");

                    b.Property<int>("TimeCCingOthers")
                        .HasColumnType("integer");

                    b.Property<int>("TimePlayed")
                        .HasColumnType("integer");

                    b.Property<int>("TotalDamageDealt")
                        .HasColumnType("integer");

                    b.Property<int>("TotalDamageDealtToChampions")
                        .HasColumnType("integer");

                    b.Property<int>("TotalDamageShieldedOnTeamates")
                        .HasColumnType("integer");

                    b.Property<int>("TotalDamageTaken")
                        .HasColumnType("integer");

                    b.Property<int>("TotalHeal")
                        .HasColumnType("integer");

                    b.Property<int>("TotalHealsOnTeamates")
                        .HasColumnType("integer");

                    b.Property<int>("TotalMinionsKilled")
                        .HasColumnType("integer");

                    b.Property<int>("TotalTimeCCDealt")
                        .HasColumnType("integer");

                    b.Property<int>("TotalTimeSpentDead")
                        .HasColumnType("integer");

                    b.Property<int>("TotalUnitsHealed")
                        .HasColumnType("integer");

                    b.Property<int>("TripleKills")
                        .HasColumnType("integer");

                    b.Property<int>("TrueDamageDealt")
                        .HasColumnType("integer");

                    b.Property<int>("TrueDamageDealtToChampions")
                        .HasColumnType("integer");

                    b.Property<int>("TrueDamageTaken")
                        .HasColumnType("integer");

                    b.Property<int>("TurretKills")
                        .HasColumnType("integer");

                    b.Property<int>("TurretTakedowns")
                        .HasColumnType("integer");

                    b.Property<int>("TurretsLost")
                        .HasColumnType("integer");

                    b.Property<int>("UnrealKills")
                        .HasColumnType("integer");

                    b.Property<int>("VisionScore")
                        .HasColumnType("integer");

                    b.Property<int>("VisionWardsBoughtInGame")
                        .HasColumnType("integer");

                    b.Property<int>("WardsKilled")
                        .HasColumnType("integer");

                    b.Property<int>("WardsPlaced")
                        .HasColumnType("integer");

                    b.Property<bool>("Win")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("ParticipantsDTO");
                });

            modelBuilder.Entity("OvStats_Website.DTO.SummonerAccountDTO", b =>
                {
                    b.Property<string>("Puuid")
                        .HasColumnType("text");

                    b.Property<string>("AccountId")
                        .HasColumnType("text");

                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<Instant>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("ProfileIconId")
                        .HasColumnType("integer");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.Property<long>("RevisionDate")
                        .HasColumnType("bigint");

                    b.Property<long>("SummonerLevel")
                        .HasColumnType("bigint");

                    b.HasKey("Puuid");

                    b.ToTable("SummonerAccount");
                });

            modelBuilder.Entity("OvStats_Website.DTO.SummonerStatsDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("FreshBlood")
                        .HasColumnType("boolean");

                    b.Property<bool>("HotStreak")
                        .HasColumnType("boolean");

                    b.Property<bool>("Inactive")
                        .HasColumnType("boolean");

                    b.Property<Instant>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LeagueId")
                        .HasColumnType("text");

                    b.Property<int>("LeaguePoints")
                        .HasColumnType("integer");

                    b.Property<int>("Losses")
                        .HasColumnType("integer");

                    b.Property<int?>("MiniSeriesId")
                        .HasColumnType("integer");

                    b.Property<string>("QueueType")
                        .HasColumnType("text");

                    b.Property<string>("Rank")
                        .HasColumnType("text");

                    b.Property<string>("SummonerId")
                        .HasColumnType("text");

                    b.Property<string>("SummonerName")
                        .HasColumnType("text");

                    b.Property<string>("Tier")
                        .HasColumnType("text");

                    b.Property<bool>("Veteran")
                        .HasColumnType("boolean");

                    b.Property<int>("Wins")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MiniSeriesId");

                    b.ToTable("SummonerStats");
                });

            modelBuilder.Entity("OvStats_Website.DTO.MatchDTO", b =>
                {
                    b.HasOne("OvStats_Website.DTO.InfoDTO", "Info")
                        .WithMany()
                        .HasForeignKey("InfoGameId");

                    b.HasOne("OvStats_Website.DTO.MetaDataDTO", "MetaData")
                        .WithMany()
                        .HasForeignKey("MetaDataId");

                    b.Navigation("Info");

                    b.Navigation("MetaData");
                });

            modelBuilder.Entity("OvStats_Website.DTO.ParticipantsDTO", b =>
                {
                    b.HasOne("OvStats_Website.DTO.InfoDTO", null)
                        .WithMany("Participants")
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OvStats_Website.DTO.SummonerStatsDTO", b =>
                {
                    b.HasOne("OvStats_Website.DTO.MiniSeries", "MiniSeries")
                        .WithMany()
                        .HasForeignKey("MiniSeriesId");

                    b.Navigation("MiniSeries");
                });

            modelBuilder.Entity("OvStats_Website.DTO.InfoDTO", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
