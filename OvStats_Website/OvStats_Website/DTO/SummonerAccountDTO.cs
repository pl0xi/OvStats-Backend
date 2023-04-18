﻿using System.ComponentModel.DataAnnotations;

namespace OvStats_Website.DTO
{
    public class SummonerAccountDTO
    {
        [Key]
        public string accountId { get; set; }
        public int profileIconId { get; set; }
        public long revisionDate { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string puuid { get; set; }
        public long summonerLevel { get; set; }
        public string region { get; set; }
    }
}
