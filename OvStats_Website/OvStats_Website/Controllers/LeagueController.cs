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

            _httpClient.DefaultRequestHeaders
                .Add("X-Riot-Token", riotAPI);
        }

        [HttpGet]
        [Route("playerInfo")]
        public String Get(string username, string region)
        {
            SummonerAccountDTO userAccount = GetAccount(username, region);
            HttpResponseMessage response = _httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/league/v4/entries/by-summoner/{userAccount.id}").Result;           
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            return content.ToString();
        }

        private static SummonerAccountDTO GetAccount(string username, string region)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{username}").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
         
            return JsonConvert.DeserializeObject<SummonerAccountDTO>(content) ?? throw new InvalidOperationException();
        }
    }
}
