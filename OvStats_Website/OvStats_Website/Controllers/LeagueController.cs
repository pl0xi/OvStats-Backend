using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OvStats_Website.DTO;

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

        // Need to convert this to ActionResult 
        [HttpGet]
        [Route("playerInfo")]
        [Produces("application/json")]
        public ActionResult GetPlayerInfo(string username, string region)
        {
            SummonerAccountDTO userAccount = GetAccount(username, region);

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", riotAPI);
            HttpResponseMessage response = _httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/league/v4/entries/by-summoner/{userAccount.id}").Result;           
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            IEnumerable<SummonerStatsDTO> summonerStats = JsonConvert.DeserializeObject<IEnumerable<SummonerStatsDTO>>(content) ?? throw new InvalidOperationException();
            summonerStats.First().summonerId = "hidden";

            return Ok(summonerStats.First());
        }

        [HttpGet]
        [Route("verifyAccount")]
        [Produces("application/json")]
        public ActionResult VerifyAccount (string username, string region)
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
