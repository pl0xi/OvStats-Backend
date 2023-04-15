using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using OvStats_Website.Clients;
using OvStats_Website.Controllers;
using OvStats_Website.DTO;
using Xunit.Abstractions;

namespace OvStats_Website_Test
{
    public class LeagueControllerTest
    {
        private readonly LeagueController _leagueController;
        private readonly ITestOutputHelper _output;

        public LeagueControllerTest(ITestOutputHelper output)
        {
            Mock<HttpClient> httpClient = new Mock<HttpClient>();
            IRiotClient riotClient = new RiotClient(httpClient.Object);
            _leagueController = new LeagueController(riotClient)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            Mock<IUrlHelper> urlHelperMock = new();
            urlHelperMock
                .Setup(url => url.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("http://localhost/summoner");
            _leagueController.Url = urlHelperMock.Object;
            _output = output;
        }

        [Fact]
        public async Task GetSummonerTest()
        {
            var result = await _leagueController.GetSummoner("sofieee", "euw1");
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            dynamic okResultDynamic = okResult.Value;
            SummonerStatsDTO summonerStats = okResultDynamic.GetType().GetProperty("data").GetValue(okResultDynamic, null) as SummonerStatsDTO;

            Assert.Equal("sofieee", summonerStats.summonerName);
        }

        [Fact]
        public async Task VerifySummonerTest()
        {
            var result = await _leagueController.VerifySummoner("sofieee", "euw1");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetSummonerMatchHistoryTest()
        {
            var result = await _leagueController.GetSummonerMatchHistory("sofieee", "euw1");
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            dynamic okResultDynamic = okResult.Value;
            dynamic data = okResultDynamic.GetType().GetProperty("data").GetValue(okResultDynamic, null);
            List<MatchDTO> matches = data.GetType().GetProperty("matches").GetValue(data, null) as List<MatchDTO>;

            Assert.Equal("EBoOMO87H7Po6QMFIG9KkztfuUrbw6KsiqBTgStOAGMorRc6PKpQ99-0OS5Hi4codxnQZMCm8WxskQ", data.GetType().GetProperty("playerPuuid").GetValue(data, null) as string);
            Assert.Equal(5, matches.Count);
        }
    }
}
