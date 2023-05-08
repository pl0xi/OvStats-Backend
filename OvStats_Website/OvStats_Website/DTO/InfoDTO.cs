using System.ComponentModel.DataAnnotations;

namespace OvStats_Website.DTO
{
    public class InfoDTO
    {
        public long GameCreation { get; set; }
        public long GameDuration { get; set; }
        public long GameEndTimestamp { get; set; }
        [Key]
        public long GameId { get; set; }
        public string GameMode { get; set; }
        public string GameName { get; set; }
        public long GameStartTimestamp { get; set; }
        public string GameType { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        // TODO: participantsDTO
        public List<ParticipantsDTO> Participants { get; set; }
        public string PlatformId { get; set; }
        public int QueueId { get; set; }
        // TODO: TeamDTO
        public string TournamentCode { get; set; }
    }
}
