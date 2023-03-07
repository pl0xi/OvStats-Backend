namespace OvStats_Website.DTO
{
    public class InfoDTO
    {
        public long gameCreation { get; set; }
        public long gameDuration { get; set; }
        public long gameEndTimestamp { get; set; }
        public long gameId { get; set; }
        public string gameMode { get; set; }
        public string gameName { get; set; }
        public long gameStartTimestamp { get; set; }
        public string gameType { get; set; }
        public string gameVersion { get; set; }
        public int mapId { get; set; }
        // TODO: participantsDTO
        public List<ParticipantsDTO> participants { get; set; }
        public string platformId { get; set; }
        public int queueId { get; set; }
        // TODO: TeamDTO
        public string tournamentCode { get; set; }
    }
}
