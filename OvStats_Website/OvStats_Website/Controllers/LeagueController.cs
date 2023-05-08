using Microsoft.AspNetCore.Mvc;
using OvStats_Website.Clients;
using OvStats_Website.DTO;

namespace OvStats_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly IRiotClient riotClient;
        private readonly IDbClient dbClient;

        public LeagueController(IRiotClient _riotClient, IDbClient _dbClient)
        {
            riotClient = _riotClient;
            dbClient = _dbClient;
        }

        [HttpGet(Name = nameof(GetSummoner))]
        [Route("summoner")]
        [Produces("application/json")]
        public async Task<ActionResult> GetSummoner(string username, string region)
        {
            SummonerAccountDTO userAccount = await dbClient.GetSummonerAccount(username, region);

            if (userAccount is null)
            {
                userAccount = await riotClient.GetAccount(username, region);
                userAccount.Region = region;
                userAccount = await dbClient.PersistSummonerAccount(userAccount);
            }

            IEnumerable<SummonerStatsDTO> summonerStats = dbClient.GetSummonerStats(userAccount.Id, region);
            if (!summonerStats.Any())
            {
                IEnumerable<SummonerStatsDTO> summonerStatsToPersist = await riotClient.GetSummonerInfo(userAccount.Id, region);
                summonerStats = await dbClient.PersistSummonerStats(summonerStatsToPersist);
            } 

            SummonerStatsDTO summonerRankedSoloStat = summonerStats.Where(queue => queue.QueueType == "RANKED_SOLO_5x5").First();

            summonerRankedSoloStat.SummonerId = "hidden";

            var returnResponse = new
            {
                href = Url.Link(nameof(GetSummoner), null),
                data = summonerRankedSoloStat
            };

            return Ok(returnResponse);
        }

        [HttpGet(Name = nameof(VerifySummoner))]
        [Route("summoner/verify")]
        [Produces("application/json")]
        public async Task<ActionResult> VerifySummoner (string username, string region)
        {
            var returnResponse = new
            {
                href = Url.Link(nameof(VerifySummoner), null),
            };

            if (await riotClient.GetAccount(username, region) is not null)
            {
                return Ok(returnResponse);
            } else
            {
                return NotFound(returnResponse);
            }
        }

        [HttpGet(Name = nameof(GetSummonerMatchHistory))]
        [Route("summoner/matches")]
        [Produces("application/json")]
        public async Task<ActionResult> GetSummonerMatchHistory(string username, string region) {
            List<MatchDTO> matches = new(); 
            SummonerAccountDTO userAccount = await riotClient.GetAccount(username, region);
            IEnumerable<string> matchesID = await riotClient.GetMatchHistoryIDs(userAccount.Puuid);

            foreach (string matchID in matchesID)
            {
                MatchDTO match_ = await riotClient.GetMatch(matchID);
                matches.Add(match_);
            }

            var returnResponse = new
            {
                href = Url.Link(nameof(GetSummonerMatchHistory), null),
                data = new { 
                    playerPuuid = userAccount.Puuid,
                    matches
                }
            };

            return Ok(returnResponse);
        }
    }
}
