using Castle.Core.Logging;
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
            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            _IRiotClient = new RiotClient(mockHttpClient.Object);
            _output = output;
        }

        [Fact]
        public async Task GetAccountTest()
        {
            string username = "sofieee";
            string region = "euw1";
            SummonerAccountDTO summonerAccountDTO = await _IRiotClient.GetAccount(username, region);

            Assert.NotNull(summonerAccountDTO.id);
            Assert.Equal("sofieee", summonerAccountDTO.name);
        }

        [Fact]
        public async Task GetSummonerInfoTest()
        {
            string userId = "EKuybWPs3S3E2seF6dk2Qj7LYpwPCpi-kFWiJek-Shhc86H9";
            string region = "euw1";
            IEnumerable<SummonerStatsDTO> summonerStats = await _IRiotClient.GetSummonerInfo(userId, region);
        
            Assert.NotNull(summonerStats);
            Assert.Contains(summonerStats, stats => stats.queueType == "RANKED_SOLO_5x5");
        }

        [Fact]
        public async Task GetMatchTest()
        {
            // This test needs refactoring every 2 years. (Limited by riot database)
            string matchId = "EUW1_6349504068";
            MatchDTO match = await _IRiotClient.GetMatch(matchId);

            Assert.NotNull(match);
            Assert.Equal(1680817137246, match.info.gameEndTimestamp);

        }
    }
}