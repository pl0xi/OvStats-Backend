using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            _httpClient.BaseAddress = new Uri("https://europe.api.riotgames.com/riot/");
            _httpClient.DefaultRequestHeaders
                .Add("X-Riot-Token", riotAPI);
        }

        [HttpGet]
        [Route("puuid")]
        public String Get(string username, string tagLine)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"account/v1/accounts/by-riot-id/{username}/{tagLine}").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            JObject jsonContent = JObject.Parse(content);
            var puuid = jsonContent.GetValue("puuid");

            if(puuid is not null)
            {
                return puuid.ToString();
            } else
            {
                return $"Unable to fetch puuid for {username}#{tagLine}";
            }
        }
    }
}
