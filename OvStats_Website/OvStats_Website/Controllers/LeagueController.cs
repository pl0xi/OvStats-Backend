using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OvStats_Website.DTO;
using System.Diagnostics;

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

        [HttpGet]
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

            return Ok(responseStats);
        }

        [HttpGet]
        [Route("summoner/verify")]
        [Produces("application/json")]
        public ActionResult VerifySummoner (string username, string region)
        {
            if(GetAccount(username, region) is not null)
            {
                return Ok();
            } else
            {
                return NotFound();
            }
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
    }
}
