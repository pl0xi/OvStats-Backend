using Microsoft.EntityFrameworkCore;
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
            SummonerAccountDTO _summoner = await db.SummonerAccount.AddAsync(summoner);
            await db.SaveChangesAsync();
            return _summoner;
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
                summonerStatsEntities.Add(await db.SummonerStats.AddAsync(stats));
            }
            await db.SaveChangesAsync();
            return summonerStatsEntities;
        }
    }

    public interface IDbClient
    {
        Task<SummonerAccountDTO> GetSummonerAccount(string username, string region);
        Task<SummonerAccountDTO> PersistSummonerAccount(SummonerAccountDTO summoner);
        IEnumerable<SummonerStatsDTO> GetSummonerStats(string userId, string region);
        Task<IEnumerable<SummonerStatsDTO>> PersistSummonerStats(IEnumerable<SummonerStatsDTO> summonerStats);
    }
}
