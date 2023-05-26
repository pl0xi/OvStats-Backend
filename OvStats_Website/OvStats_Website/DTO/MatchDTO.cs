using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace OvStats_Website.DTO
{
    public class MatchDTO
    {
        [Key]
        public string MatchId { get; set; }
        public InfoDTO Info { get; set; }
        public MetaDataDTO MetaData { get; set; }

        public static implicit operator MatchDTO(EntityEntry<MatchDTO> v)
        {
            return v.Entity;
        }
    }
}
