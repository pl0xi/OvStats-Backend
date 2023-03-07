using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OvStats_Website.DTO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OvStats_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private string riotAPI = string.Empty;
        private readonly ILogger _logger;
        private static HttpClient _httpClient = new HttpClient();
        public LeagueController(ILogger<LeagueController> logger) {
            _logger = logger;

            using (StreamReader r = new("OvStats_config/ovstats_config.json"))
            {
                string json = r.ReadToEnd();
                JObject jsonObject = JObject.Parse(json);
                if(jsonObject.First is not null && jsonObject.First.First is not null)
                {
                    riotAPI = jsonObject.First.First.ToString();
                }  else
                {
                    _logger.LogInformation("Unable to read riot API");
                }
            }
        }

        [HttpGet(Name = nameof(GetSummoner))]
        [Route("summoner")]
        [Produces("application/json")]
        public ActionResult GetSummoner(string username, string region)
        {
            SummonerAccountDTO userAccount = GetAccount(username, region);

            if(userAccount is null)
            {
                return NotFound("Something went wrong.");
            }

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", riotAPI);
            HttpResponseMessage response = _httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/league/v4/entries/by-summoner/{userAccount.id}").Result;           
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            IEnumerable<SummonerStatsDTO> summonerStats = JsonConvert.DeserializeObject<IEnumerable<SummonerStatsDTO>>(content) ?? throw new InvalidOperationException();
            SummonerStatsDTO responseStats = summonerStats.Where(summonerStats_ => summonerStats_.queueType == "RANKED_SOLO_5x5").First();
            responseStats.summonerId = "hidden";

            var returnResponse = new
            {
                href = Url.Link(nameof(GetSummoner), null),
                data = responseStats
            };

            return Ok(returnResponse);
        }

        [HttpGet(Name = nameof(VerifySummoner))]
        [Route("summoner/verify")]
        [Produces("application/json")]
        public ActionResult VerifySummoner (string username, string region)
        {
            var returnResponse = new
            {
                href = Url.Link(nameof(VerifySummoner), null),
            };

            if (GetAccount(username, region) is not null)
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
        public ActionResult GetSummonerMatchHistory(string username, string region) {
            List<MatchDTO> matches = new List<MatchDTO>(); 
            SummonerAccountDTO userAccount = GetAccount(username, region);

            if (userAccount is null)
            {
                return NotFound("Something went wrong.");
            }

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", riotAPI);
            HttpResponseMessage response = _httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/{userAccount.puuid}/ids?start=0&count=5&type=ranked").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            IEnumerable<string> result = JsonConvert.DeserializeObject<IEnumerable<string>>(content) ?? throw new InvalidOperationException();
            
            foreach (var match in result)
            {
                MatchDTO match_ = GetMatch(match);
                matches.Add(match_);
            }


            var returnResponse = new
            {
                href = Url.Link(nameof(GetSummonerMatchHistory), null),
                data = new { 
                    playerPuuid = userAccount.puuid,
                    matches =  matches
                }
            };

            return Ok(returnResponse);
        }

        private SummonerAccountDTO GetAccount(string username, string region)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", riotAPI);
            HttpResponseMessage response = _httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{username}").Result;
            if (((int)response.StatusCode) != 200)
            {
                return null;
            } 
            var content = response.Content.ReadAsStringAsync().Result;
            
            return JsonConvert.DeserializeObject<SummonerAccountDTO>(content) ?? throw new InvalidOperationException();
        }

        private MatchDTO GetMatch(string matchID)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", riotAPI);
            HttpResponseMessage response = _httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/{matchID}").Result;
            if (((int)response.StatusCode) != 200)
            {
                return null;
            }
            var content = response.Content.ReadAsStringAsync().Result;


            return JsonConvert.DeserializeObject<MatchDTO>(content) ?? throw new InvalidOperationException();
        }
    }
}
