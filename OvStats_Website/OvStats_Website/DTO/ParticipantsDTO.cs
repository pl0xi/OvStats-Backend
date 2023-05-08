﻿using System.ComponentModel.DataAnnotations;

namespace OvStats_Website.DTO
{
    public class ParticipantsDTO
    {
        [Key]
        public int Id { get; set; }
        public int Assists { get; set; }
        public int BaronKills { get; set; }
        public int BountyKills { get; set; }
        public int ChampExperience { get; set; }
        public int ChampLevel { get; set; }
        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public int ChampionTransform { get; set; }
        public int ConsumablesPurchased { get; set; }
        public int DamageDealtToBuildings { get; set; }
        public int DamageDealtToObjectives { get; set; }
        public int DamageDealtToTurrets { get; set; }
        public int DamageSelfMitigated { get; set; }
        public int Deaths { get; set; }
        public int DetectorWardsPlaced { get; set; }
        public int DoubleKills { get; set; }
        public int DragonKills { get; set; }
        public bool FirstBloodAssist { get; set; }
        public bool FirstBloodKill { get; set; }
        public bool FirstTowerAssist { get; set; }
        public bool FirstTowerKill { get; set; }
        public bool GameEndedInEarlySurrender { get; set; }
        public int GoldEarned { get; set; }
        public int GoldSpent { get; set; }
        public string IndivdualPosition { get; set; }
        public int InhibitorKills { get; set; }
        public int InhibitorTakedowns { get; set; }
        public int InhibitorsLost { get; set; }
        public int Item0 { get; set; }
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public int Item3 { get; set; }
        public int Item4 { get; set; }
        public int Item5 { get; set; }
        public int Item6 { get; set; }
        public int ItemsPurchased { get; set; }
        public int KillingSprees { get; set; }
        public int Kills { get; set; }
        public string Lane { get; set; }
        public int LargestCriticalStrike { get; set; }
        public int LargestMultiKill { get; set; }
        public int LongestTimeSpentAlive { get; set; }
        public int MagicDamageDealt { get; set; }
        public int MagicDamageDealtToChampions { get; set; }
        public int MagicDamageTaken { get; set; }
        public int NeutralMinionsKilled { get; set; }
        public int NexusKills { get; set; }
        public int NexusTakedowns { get; set; }
        public int NexusLost { get; set; }
        public int ObjectivesStolen { get; set; }
        public int ObjectivesStolenAssists { get; set; }
        public int ParticipantId { get; set; }
        public int PentaKills { get; set; }
        // MISSING PERKSDTO
        public int PhysicalDamageDealt { get; set; }
        public int PhysicalDamageDealtToChampions { get; set; }
        public int PhysicalDamageTaken { get; set; }
        public int ProfileIcon { get; set; }
        public string Puuid { get; set; }
        public int QuadraKills { get; set; }
        public string RiotIdName { get; set; }
        public string RiotIdTagline { get; set; }
        public string Role { get; set; }
        public int SightWardsBoughtInGame { get; set; }
        public int Spell1Casts { get; set; }
        public int Spell2Casts { get; set; }
        public int Spell3Casts { get; set; }
        public int Spell4Casts { get; set; }
        public int Summoner1Casts { get; set; }
        public int Summoner1Id { get; set; }
        public int Summoner2Casts { get; set; }
        public int Summoner2Id { get;set; }
        public string Summonerid { get; set; }
        public bool TeamEarlySurrendered { get; set; }
        public int TeamId { get; set; }
        public string TeamPosition { get; set; }
        public int TimeCCingOthers { get; set; }
        public int TimePlayed { get; set; }
        public int TotalDamageDealt { get; set; }
        public int TotalDamageDealtToChampions { get; set; }
        public int TotalDamageShieldedOnTeamates { get; set; }
        public int TotalDamageTaken { get; set; }
        public int TotalHeal { get; set; }
        public int TotalHealsOnTeamates { get; set; }
        public int TotalMinionsKilled { get; set; }
        public int TotalTimeCCDealt { get; set; }
        public int TotalTimeSpentDead { get; set; }
        public int TotalUnitsHealed { get; set; }
        public int TripleKills { get; set; }
        public int TrueDamageDealt { get; set; }
        public int TrueDamageDealtToChampions { get; set; }
        public int TrueDamageTaken { get; set; }
        public int TurretKills { get; set; }
        public int TurretTakedowns { get; set; }
        public int TurretsLost { get; set; }
        public int UnrealKills { get; set; }
        public int VisionScore { get; set; }
        public int VisionWardsBoughtInGame { get; set; }
        public int WardsKilled { get; set; }
        public int WardsPlaced { get; set; }
        public bool Win { get; set; }
    }
}
