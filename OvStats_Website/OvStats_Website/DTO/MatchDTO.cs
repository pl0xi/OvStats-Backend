using System.ComponentModel.DataAnnotations;

namespace OvStats_Website.DTO
{
    public class MatchDTO
    {
        [Key]
        public int Id { get; set; }
        public InfoDTO Info { get; set; }
    }
}
