using Microsoft.EntityFrameworkCore;
using NodaTime;
using OvStats_Website.DBContext;
using OvStats_Website.DTO;

namespace OvStats_Website.Clients
{
    public class DbClient : IDbClient
    {
        private readonly AppDBContext db;
        public DbClient(AppDBContext _db)
        {
            db = _db;
        }

        public async Task<SummonerAccountDTO> GetSummonerAccount(string username, string region)
        {
            SummonerAccountDTO summoner = await db.SummonerAccount.FirstOrDefaultAsync(summoner => summoner.Name == username && summoner.Region == region);
            return summoner;
        } 

        public async Task<SummonerAccountDTO> PersistSummonerAccount(SummonerAccountDTO summoner)
        {
            summoner.LastUpdated = SystemClock.Instance.GetCurrentInstant();
            SummonerAccountDTO _summoner = await db.SummonerAccount.AddAsync(summoner);
            await db.SaveChangesAsync();
            return _summoner;
        }

        public async Task<SummonerAccountDTO> UpdateSummonerAccount(SummonerAccountDTO summonerAccount, SummonerAccountDTO riotSummonerAccount)
        {
            summonerAccount.AccountId = riotSummonerAccount.AccountId;
            summonerAccount.ProfileIconId = riotSummonerAccount.ProfileIconId;
            summonerAccount.RevisionDate = riotSummonerAccount.RevisionDate;
            summonerAccount.Name = riotSummonerAccount.Name;
            summonerAccount.Id = riotSummonerAccount.Id;
            summonerAccount.SummonerLevel = riotSummonerAccount.SummonerLevel;
            summonerAccount.LastUpdated = SystemClock.Instance.GetCurrentInstant();

            await db.SaveChangesAsync();
            return summonerAccount;
        }

        public IEnumerable<SummonerStatsDTO> GetSummonerStats(string userId, string region)
        {
            IEnumerable<SummonerStatsDTO> summonerStats = db.SummonerStats.Where(statEntity => statEntity.SummonerId == userId).AsEnumerable();
            return summonerStats;
        }

        public async Task<IEnumerable<SummonerStatsDTO>> PersistSummonerStats(IEnumerable<SummonerStatsDTO> summonerStats)
        {
            List<SummonerStatsDTO> summonerStatsEntities = new();
            foreach(SummonerStatsDTO stats in summonerStats)
            {
                stats.LastUpdated = SystemClock.Instance.GetCurrentInstant();
                summonerStatsEntities.Add(await db.SummonerStats.AddAsync(stats));
            }
            await db.SaveChangesAsync();
            return summonerStatsEntities;
        }

        public async Task<IEnumerable<SummonerStatsDTO>> UpdateSummonerStats(IEnumerable<SummonerStatsDTO> summonerStats, IEnumerable<SummonerStatsDTO> riotSummonerStats)
        {
            foreach(SummonerStatsDTO stats in summonerStats)
            {
                SummonerStatsDTO riotStats = riotSummonerStats.Where((riotStatEntity) => riotStatEntity.QueueType == stats.QueueType).First();
                stats.LastUpdated = SystemClock.Instance.GetCurrentInstant();
                stats.LeagueId = riotStats.LeagueId;
                stats.SummonerId = riotStats.SummonerId;
                stats.SummonerName = riotStats.SummonerName;
                stats.Tier = riotStats.Tier;
                stats.Rank = riotStats.Rank;
                stats.LeaguePoints = riotStats.LeaguePoints;
                stats.Wins = riotStats.Wins;
                stats.Losses = riotStats.Losses;
                stats.HotStreak = riotStats.HotStreak;
                stats.Veteran = riotStats.Veteran;
                stats.FreshBlood = riotStats.FreshBlood;
                stats.Inactive = riotStats.Inactive;
                stats.MiniSeries = riotStats.MiniSeries;
            }

            await db.SaveChangesAsync();

            return summonerStats;
        }
    }

    public interface IDbClient
    {
        Task<SummonerAccountDTO> GetSummonerAccount(string username, string region);
        Task<SummonerAccountDTO> PersistSummonerAccount(SummonerAccountDTO summoner);
        IEnumerable<SummonerStatsDTO> GetSummonerStats(string userId, string region);
        Task<IEnumerable<SummonerStatsDTO>> PersistSummonerStats(IEnumerable<SummonerStatsDTO> summonerStats);
        Task<SummonerAccountDTO> UpdateSummonerAccount(SummonerAccountDTO summonerAccount, SummonerAccountDTO riotSummonerAccount);
        Task<IEnumerable<SummonerStatsDTO>> UpdateSummonerStats(IEnumerable<SummonerStatsDTO> summonerStats, IEnumerable<SummonerStatsDTO> riotSummonerStats);
    }
}
