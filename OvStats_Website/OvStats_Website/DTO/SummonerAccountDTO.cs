using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace OvStats_Website.DTO
{
    public class SummonerAccountDTO
    {
        public string AccountId { get; set; }
        public int ProfileIconId { get; set; }
        public long RevisionDate { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        [Key]
        public string Puuid { get; set; }
        public long SummonerLevel { get; set; }
        public string Region { get; set; }

        public static implicit operator SummonerAccountDTO(EntityEntry<SummonerAccountDTO> v)
        {
            return v.Entity;
        }
    }
}
