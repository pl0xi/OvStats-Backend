using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OvStats_Website.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoDTO",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameCreation = table.Column<long>(type: "bigint", nullable: false),
                    GameDuration = table.Column<long>(type: "bigint", nullable: false),
                    GameEndTimestamp = table.Column<long>(type: "bigint", nullable: false),
                    GameMode = table.Column<string>(type: "text", nullable: true),
                    GameName = table.Column<string>(type: "text", nullable: true),
                    GameStartTimestamp = table.Column<long>(type: "bigint", nullable: false),
                    GameType = table.Column<string>(type: "text", nullable: true),
                    GameVersion = table.Column<string>(type: "text", nullable: true),
                    MapId = table.Column<int>(type: "integer", nullable: false),
                    PlatformId = table.Column<string>(type: "text", nullable: true),
                    QueueId = table.Column<int>(type: "integer", nullable: false),
                    TournamentCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoDTO", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "MiniSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Losses = table.Column<int>(type: "integer", nullable: false),
                    Progress = table.Column<string>(type: "text", nullable: true),
                    Target = table.Column<int>(type: "integer", nullable: false),
                    Wins = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SummonerAccount",
                columns: table => new
                {
                    Puuid = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<string>(type: "text", nullable: true),
                    ProfileIconId = table.Column<int>(type: "integer", nullable: false),
                    RevisionDate = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: true),
                    SummonerLevel = table.Column<long>(type: "bigint", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: true),
                    LastUpdated = table.Column<Instant>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummonerAccount", x => x.Puuid);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InfoGameId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_InfoDTO_InfoGameId",
                        column: x => x.InfoGameId,
                        principalTable: "InfoDTO",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateTable(
                name: "ParticipantsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Assists = table.Column<int>(type: "integer", nullable: false),
                    BaronKills = table.Column<int>(type: "integer", nullable: false),
                    BountyKills = table.Column<int>(type: "integer", nullable: false),
                    ChampExperience = table.Column<int>(type: "integer", nullable: false),
                    ChampLevel = table.Column<int>(type: "integer", nullable: false),
                    ChampionId = table.Column<int>(type: "integer", nullable: false),
                    ChampionName = table.Column<string>(type: "text", nullable: true),
                    ChampionTransform = table.Column<int>(type: "integer", nullable: false),
                    ConsumablesPurchased = table.Column<int>(type: "integer", nullable: false),
                    DamageDealtToBuildings = table.Column<int>(type: "integer", nullable: false),
                    DamageDealtToObjectives = table.Column<int>(type: "integer", nullable: false),
                    DamageDealtToTurrets = table.Column<int>(type: "integer", nullable: false),
                    DamageSelfMitigated = table.Column<int>(type: "integer", nullable: false),
                    Deaths = table.Column<int>(type: "integer", nullable: false),
                    DetectorWardsPlaced = table.Column<int>(type: "integer", nullable: false),
                    DoubleKills = table.Column<int>(type: "integer", nullable: false),
                    DragonKills = table.Column<int>(type: "integer", nullable: false),
                    FirstBloodAssist = table.Column<bool>(type: "boolean", nullable: false),
                    FirstBloodKill = table.Column<bool>(type: "boolean", nullable: false),
                    FirstTowerAssist = table.Column<bool>(type: "boolean", nullable: false),
                    FirstTowerKill = table.Column<bool>(type: "boolean", nullable: false),
                    GameEndedInEarlySurrender = table.Column<bool>(type: "boolean", nullable: false),
                    GoldEarned = table.Column<int>(type: "integer", nullable: false),
                    GoldSpent = table.Column<int>(type: "integer", nullable: false),
                    IndivdualPosition = table.Column<string>(type: "text", nullable: true),
                    InhibitorKills = table.Column<int>(type: "integer", nullable: false),
                    InhibitorTakedowns = table.Column<int>(type: "integer", nullable: false),
                    InhibitorsLost = table.Column<int>(type: "integer", nullable: false),
                    Item0 = table.Column<int>(type: "integer", nullable: false),
                    Item1 = table.Column<int>(type: "integer", nullable: false),
                    Item2 = table.Column<int>(type: "integer", nullable: false),
                    Item3 = table.Column<int>(type: "integer", nullable: false),
                    Item4 = table.Column<int>(type: "integer", nullable: false),
                    Item5 = table.Column<int>(type: "integer", nullable: false),
                    Item6 = table.Column<int>(type: "integer", nullable: false),
                    ItemsPurchased = table.Column<int>(type: "integer", nullable: false),
                    KillingSprees = table.Column<int>(type: "integer", nullable: false),
                    Kills = table.Column<int>(type: "integer", nullable: false),
                    Lane = table.Column<string>(type: "text", nullable: true),
                    LargestCriticalStrike = table.Column<int>(type: "integer", nullable: false),
                    LargestMultiKill = table.Column<int>(type: "integer", nullable: false),
                    LongestTimeSpentAlive = table.Column<int>(type: "integer", nullable: false),
                    MagicDamageDealt = table.Column<int>(type: "integer", nullable: false),
                    MagicDamageDealtToChampions = table.Column<int>(type: "integer", nullable: false),
                    MagicDamageTaken = table.Column<int>(type: "integer", nullable: false),
                    NeutralMinionsKilled = table.Column<int>(type: "integer", nullable: false),
                    NexusKills = table.Column<int>(type: "integer", nullable: false),
                    NexusTakedowns = table.Column<int>(type: "integer", nullable: false),
                    NexusLost = table.Column<int>(type: "integer", nullable: false),
                    ObjectivesStolen = table.Column<int>(type: "integer", nullable: false),
                    ObjectivesStolenAssists = table.Column<int>(type: "integer", nullable: false),
                    ParticipantId = table.Column<int>(type: "integer", nullable: false),
                    PentaKills = table.Column<int>(type: "integer", nullable: false),
                    PhysicalDamageDealt = table.Column<int>(type: "integer", nullable: false),
                    PhysicalDamageDealtToChampions = table.Column<int>(type: "integer", nullable: false),
                    PhysicalDamageTaken = table.Column<int>(type: "integer", nullable: false),
                    ProfileIcon = table.Column<int>(type: "integer", nullable: false),
                    Puuid = table.Column<string>(type: "text", nullable: true),
                    QuadraKills = table.Column<int>(type: "integer", nullable: false),
                    RiotIdName = table.Column<string>(type: "text", nullable: true),
                    RiotIdTagline = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    SightWardsBoughtInGame = table.Column<int>(type: "integer", nullable: false),
                    Spell1Casts = table.Column<int>(type: "integer", nullable: false),
                    Spell2Casts = table.Column<int>(type: "integer", nullable: false),
                    Spell3Casts = table.Column<int>(type: "integer", nullable: false),
                    Spell4Casts = table.Column<int>(type: "integer", nullable: false),
                    Summoner1Casts = table.Column<int>(type: "integer", nullable: false),
                    Summoner1Id = table.Column<int>(type: "integer", nullable: false),
                    Summoner2Casts = table.Column<int>(type: "integer", nullable: false),
                    Summoner2Id = table.Column<int>(type: "integer", nullable: false),
                    Summonerid = table.Column<string>(type: "text", nullable: true),
                    TeamEarlySurrendered = table.Column<bool>(type: "boolean", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamPosition = table.Column<string>(type: "text", nullable: true),
                    TimeCCingOthers = table.Column<int>(type: "integer", nullable: false),
                    TimePlayed = table.Column<int>(type: "integer", nullable: false),
                    TotalDamageDealt = table.Column<int>(type: "integer", nullable: false),
                    TotalDamageDealtToChampions = table.Column<int>(type: "integer", nullable: false),
                    TotalDamageShieldedOnTeamates = table.Column<int>(type: "integer", nullable: false),
                    TotalDamageTaken = table.Column<int>(type: "integer", nullable: false),
                    TotalHeal = table.Column<int>(type: "integer", nullable: false),
                    TotalHealsOnTeamates = table.Column<int>(type: "integer", nullable: false),
                    TotalMinionsKilled = table.Column<int>(type: "integer", nullable: false),
                    TotalTimeCCDealt = table.Column<int>(type: "integer", nullable: false),
                    TotalTimeSpentDead = table.Column<int>(type: "integer", nullable: false),
                    TotalUnitsHealed = table.Column<int>(type: "integer", nullable: false),
                    TripleKills = table.Column<int>(type: "integer", nullable: false),
                    TrueDamageDealt = table.Column<int>(type: "integer", nullable: false),
                    TrueDamageDealtToChampions = table.Column<int>(type: "integer", nullable: false),
                    TrueDamageTaken = table.Column<int>(type: "integer", nullable: false),
                    TurretKills = table.Column<int>(type: "integer", nullable: false),
                    TurretTakedowns = table.Column<int>(type: "integer", nullable: false),
                    TurretsLost = table.Column<int>(type: "integer", nullable: false),
                    UnrealKills = table.Column<int>(type: "integer", nullable: false),
                    VisionScore = table.Column<int>(type: "integer", nullable: false),
                    VisionWardsBoughtInGame = table.Column<int>(type: "integer", nullable: false),
                    WardsKilled = table.Column<int>(type: "integer", nullable: false),
                    WardsPlaced = table.Column<int>(type: "integer", nullable: false),
                    Win = table.Column<bool>(type: "boolean", nullable: false),
                    InfoDTOGameId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantsDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantsDTO_InfoDTO_InfoDTOGameId",
                        column: x => x.InfoDTOGameId,
                        principalTable: "InfoDTO",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateTable(
                name: "SummonerStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeagueId = table.Column<string>(type: "text", nullable: true),
                    SummonerId = table.Column<string>(type: "text", nullable: true),
                    SummonerName = table.Column<string>(type: "text", nullable: true),
                    QueueType = table.Column<string>(type: "text", nullable: true),
                    Tier = table.Column<string>(type: "text", nullable: true),
                    Rank = table.Column<string>(type: "text", nullable: true),
                    LeaguePoints = table.Column<int>(type: "integer", nullable: false),
                    Wins = table.Column<int>(type: "integer", nullable: false),
                    Losses = table.Column<int>(type: "integer", nullable: false),
                    HotStreak = table.Column<bool>(type: "boolean", nullable: false),
                    Veteran = table.Column<bool>(type: "boolean", nullable: false),
                    FreshBlood = table.Column<bool>(type: "boolean", nullable: false),
                    Inactive = table.Column<bool>(type: "boolean", nullable: false),
                    MiniSeriesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummonerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummonerStats_MiniSeries_MiniSeriesId",
                        column: x => x.MiniSeriesId,
                        principalTable: "MiniSeries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_InfoGameId",
                table: "Matches",
                column: "InfoGameId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantsDTO_InfoDTOGameId",
                table: "ParticipantsDTO",
                column: "InfoDTOGameId");

            migrationBuilder.CreateIndex(
                name: "IX_SummonerStats_MiniSeriesId",
                table: "SummonerStats",
                column: "MiniSeriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "ParticipantsDTO");

            migrationBuilder.DropTable(
                name: "SummonerAccount");

            migrationBuilder.DropTable(
                name: "SummonerStats");

            migrationBuilder.DropTable(
                name: "InfoDTO");

            migrationBuilder.DropTable(
                name: "MiniSeries");
        }
    }
}
