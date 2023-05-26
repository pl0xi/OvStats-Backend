using System.ComponentModel.DataAnnotations;

namespace OvStats_Website.DTO
{
    public class MetaDataDTO
    {
        [Key]
        public int Id { get; set; }
        public string DataVersion { get; set; }
        public string MatchID { get; set; }
    }
}
