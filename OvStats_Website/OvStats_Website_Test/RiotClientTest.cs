using Castle.Core.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using OvStats_Website.Clients;
using OvStats_Website.DTO;
using Xunit.Abstractions;

namespace OvStats_Website_Test
{
    public class RiotClientTest
    {
        private readonly IRiotClient _IRiotClient;
        private readonly ITestOutputHelper _output;


        public RiotClientTest(ITestOutputHelper output)
        {
            Mock<HttpClient> mockHttpClient = new();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets("c9800722-e142-4131-b608-2f7c875679c7");

            IConfiguration config = builder.Build();
            _IRiotClient = new RiotClient(mockHttpClient.Object, config);
            _output = output;
        }

        [Fact]
        public async Task GetAccountTest()
        {
            string username = "sofieee";
            string region = "euw1";
            SummonerAccountDTO summonerAccountDTO = await _IRiotClient.GetAccount(username, region);

            Assert.NotNull(summonerAccountDTO.Id);
            Assert.Equal("sofieee", summonerAccountDTO.Name);
        }

        [Fact]
        public async Task GetSummonerInfoTest()
        {
            string userId = "EKuybWPs3S3E2seF6dk2Qj7LYpwPCpi-kFWiJek-Shhc86H9";
            string region = "euw1";
            IEnumerable<SummonerStatsDTO> summonerStats = await _IRiotClient.GetSummonerInfo(userId, region);
        
            Assert.NotNull(summonerStats);
            Assert.Contains(summonerStats, stats => stats.QueueType == "RANKED_SOLO_5x5");
        }

        [Fact]
        public async Task GetMatchTest()
        {
            // This test needs refactoring every 2 years. (Limited by riot database)
            string matchId = "EUW1_6349504068";
            MatchDTO match = await _IRiotClient.GetMatch(matchId);

            Assert.NotNull(match);
            Assert.Equal(1680817137246, match.Info.GameEndTimestamp);

        }

        [Fact]
        public async Task GetMatchHistoryIDsTest()
        {
            string puuid = "EBoOMO87H7Po6QMFIG9KkztfuUrbw6KsiqBTgStOAGMorRc6PKpQ99-0OS5Hi4codxnQZMCm8WxskQ";
            IEnumerable<string> matches = await _IRiotClient.GetMatchHistoryIDs(puuid);

            Assert.Equal(5, matches.Count());
        }
    }
}