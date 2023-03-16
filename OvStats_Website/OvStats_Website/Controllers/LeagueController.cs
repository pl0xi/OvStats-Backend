using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OvStats_Website.DTO;

namespace OvStats_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly IRiotClient riotClient;

        public LeagueController(IRiotClient _riotClient)
        {
            riotClient = _riotClient;
        }

        [HttpGet(Name = nameof(GetSummoner))]
        [Route("summoner")]
        [Produces("application/json")]
        public async Task<ActionResult> GetSummoner(string username, string region)
        {
            SummonerAccountDTO userAccount = await riotClient.GetAccount(username, region);
            IEnumerable<SummonerStatsDTO> summonerInfo = await riotClient.GetSummonerInfo(userAccount.id, region);

            SummonerStatsDTO summonerStat = summonerInfo.Where(queue => queue.queueType == "RANKED_SOLO_5x5").First();
            summonerStat.summonerId = "hidden";

            var returnResponse = new
            {
                href = Url.Link(nameof(GetSummoner), null),
                data = summonerStat
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
            List<MatchDTO> matches = new List<MatchDTO>(); 
            SummonerAccountDTO userAccount = await riotClient.GetAccount(username, region);
            IEnumerable<string> matchesID = await riotClient.GetMatchHistoryIDs(userAccount.puuid);

            foreach (string matchID in matchesID)
            {
                MatchDTO match_ = await riotClient.GetMatch(matchID);
                matches.Add(match_);
            }

            var returnResponse = new
            {
                href = Url.Link(nameof(GetSummonerMatchHistory), null),
                data = new { 
                    playerPuuid = userAccount.puuid,
                    matches
                }
            };

            return Ok(returnResponse);
        }
    }
}
