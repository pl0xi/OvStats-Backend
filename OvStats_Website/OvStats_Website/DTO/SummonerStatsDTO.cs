using Microsoft.EntityFrameworkCore.ChangeTracking;
using NodaTime;
using System.ComponentModel.DataAnnotations;

namespace OvStats_Website.DTO
{
    public class SummonerStatsDTO
    {
        [Key]
        public int Id { get; set; }
        public string LeagueId { get; set; }
        public string SummonerId { get; set; }
        public string SummonerName { get; set; }
        public string QueueType { get; set; }
        public string Tier { get; set; }
        public string Rank { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool HotStreak { get; set; }
        public bool Veteran { get; set; }
        public bool FreshBlood { get; set; }
        public bool Inactive { get; set; }
        public MiniSeries MiniSeries { get; set; }
        public Instant LastUpdated { get; set; }

        public static implicit operator SummonerStatsDTO(EntityEntry<SummonerStatsDTO> v)
        {
            return v.Entity;
        }
    }

    public class MiniSeries
    {
        [Key] 
        public int Id { get; set; }
        public int Losses { get; set; }
        public string Progress { get; set; }
        public int Target { get; set; }
        public int Wins { get; set; }
    }

}
