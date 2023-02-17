using Newtonsoft.Json;

namespace OvStats_Website.DTO
{
    public class SummonerStatsDTO
    {
        public string leagueId { get; set; }
        public string summonerId { get; set; }
        public string summonerName { get; set; }
        public string queueType { get; set; }
        public string tier { get; set; }
        public string rank { get; set; }
        public int leaguePoints { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public bool hotStreak { get; set; }
        public bool veteran { get; set; }
        public bool freshBlood { get; set; }
        public bool inactive { get; set; }
        public MiniSeries miniSeries { get; set; }
    }

    public class MiniSeries
    {
        public int losses { get; set; }
        public string progress { get; set; }
        public int target { get; set; }
        public int wins { get; set; }
    }
}
