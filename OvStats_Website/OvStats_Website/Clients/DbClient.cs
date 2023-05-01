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
            SummonerAccountDTO summoner = await db.SummonerAccount.FirstOrDefaultAsync(summoner => summoner.name == username && summoner.region == region);
            return summoner;
        } 

        public async Task<SummonerAccountDTO> PersistSummonerAccount(SummonerAccountDTO summoner)
        {
            SummonerAccountDTO _summoner = await db.SummonerAccount.AddAsync(summoner);
            await db.SaveChangesAsync();
            return _summoner;
        }
    }

    public interface IDbClient
    {
        Task<SummonerAccountDTO> GetSummonerAccount(string username, string region);
        Task<SummonerAccountDTO> PersistSummonerAccount(SummonerAccountDTO summoner);
    }
}
