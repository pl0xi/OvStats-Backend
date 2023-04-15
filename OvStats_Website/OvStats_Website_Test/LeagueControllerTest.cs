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
    }
}
