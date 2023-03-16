using Newtonsoft.Json;
using OvStats_Website.DTO;

namespace OvStats_Website.Clients
{
    public class RiotClient : IRiotClient
    {
        private readonly HttpClient _httpClient;
        private readonly string riotApiKey = "*";

        public RiotClient(HttpClient httpClient) {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", riotApiKey);
        }

        public async Task<SummonerAccountDTO> GetAccount(string username, string region)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{username}");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SummonerAccountDTO>(content) ?? throw new InvalidOperationException();
        }

        public async Task<IEnumerable<SummonerStatsDTO>> GetSummonerInfo(string userId, string region)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/league/v4/entries/by-summoner/{userId}");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<SummonerStatsDTO> summonerStats = JsonConvert.DeserializeObject<IEnumerable<SummonerStatsDTO>>(content) ?? throw new InvalidOperationException();

            return summonerStats;
        }

        public async Task<MatchDTO> GetMatch(string matchID)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/{matchID}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<MatchDTO>(content) ?? throw new InvalidOperationException();
        }

        public async Task<IEnumerable<string>> GetMatchHistoryIDs(string userAccountPuuid) {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/{userAccountPuuid}/ids?start=0&count=5&type=ranked");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<string>>(content) ?? throw new InvalidOperationException();
    }
    }
}

public interface IRiotClient
{
    Task<SummonerAccountDTO> GetAccount(string username, string region);
    Task<IEnumerable<SummonerStatsDTO>> GetSummonerInfo(string userId, string region);
    Task<MatchDTO> GetMatch(string matchID);
    Task<IEnumerable<string>> GetMatchHistoryIDs(string userAccountPuuid);
}
