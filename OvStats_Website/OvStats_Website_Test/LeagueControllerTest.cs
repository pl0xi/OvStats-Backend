using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using OvStats_Website.Clients;
using OvStats_Website.Controllers;
using OvStats_Website.DBContext;
using OvStats_Website.DTO;
using Xunit.Abstractions;

namespace OvStats_Website_Test
{
    public class LeagueControllerTest : IDisposable
    {
        private readonly LeagueController _leagueController;
        private readonly ITestOutputHelper _output;
        private AppDBContext _dbContext;
        private readonly DbContextOptions<AppDBContext> databaseOptions;

        public LeagueControllerTest(ITestOutputHelper output)
        {
            Mock<HttpClient> httpClient = new();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets("c9800722-e142-4131-b608-2f7c875679c7"); 

            IConfiguration config = builder.Build();
            IRiotClient riotClient = new RiotClient(httpClient.Object, config);

            databaseOptions = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new AppDBContext(databaseOptions);
            IDbClient dbClient = new DbClient(_dbContext);

            _leagueController = new LeagueController(riotClient, dbClient)
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

        public void Dispose()
        {
            _dbContext.Dispose();
            _dbContext = new AppDBContext(databaseOptions);
            GC.SuppressFinalize(this);
        }

        [Fact]
        public async Task GetSummonerTest()
        {
            var result = await _leagueController.GetSummoner("sofieee", "euw1");
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            dynamic okResultDynamic = okResult.Value ?? throw new ArgumentException("NULL ERROR");
            SummonerStatsDTO summonerStats = okResultDynamic.GetType().GetProperty("data").GetValue(okResultDynamic, null) as SummonerStatsDTO ?? throw new ArgumentException("NULL ERROR");

            Assert.Equal("sofieee", summonerStats.SummonerName);
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
            dynamic okResultDynamic = okResult.Value ?? throw new ArgumentException("NULL ERROR");
            dynamic data = okResultDynamic.GetType().GetProperty("data").GetValue(okResultDynamic, null);
            List<MatchDTO> matches = data.GetType().GetProperty("matches").GetValue(data, null) as List<MatchDTO> ?? throw new ArgumentException("NULL ERROR");

            Assert.Equal("EBoOMO87H7Po6QMFIG9KkztfuUrbw6KsiqBTgStOAGMorRc6PKpQ99-0OS5Hi4codxnQZMCm8WxskQ", data.GetType().GetProperty("playerPuuid").GetValue(data, null) as string);
            Assert.Equal(5, matches.Count);
        }


        [Fact]
        public async Task GetSummonerDatabasePersistAndPullTest()
        {
            var summonerName = "sofieee";
            var summonerRegion = "euw1";
            
            // Persist summoner in local database 
            var resultPersist = await _leagueController.GetSummoner(summonerName, summonerRegion);
            Assert.NotNull(resultPersist);

            // Pull summoner from local database via. _dbContext
            SummonerAccountDTO resultDbContext = await _dbContext.SummonerAccount.FirstOrDefaultAsync(search => search.Name == summonerName && search.Region == summonerRegion) ?? throw new ArgumentException("NULL ERROR");
            Assert.Equal(summonerName, resultDbContext.Name);
            Assert.Equal(summonerRegion, resultDbContext.Region);
            Assert.Equal("EBoOMO87H7Po6QMFIG9KkztfuUrbw6KsiqBTgStOAGMorRc6PKpQ99-0OS5Hi4codxnQZMCm8WxskQ", resultDbContext.Puuid);

            // Pull summoner from local database via. LeagueController
            var resultLeagueController = await _leagueController.GetSummoner(summonerName, summonerRegion);
            OkObjectResult resultLeagueControllerOk = Assert.IsType<OkObjectResult>(resultLeagueController);
            dynamic resultLeagueControllerDynamic = resultLeagueControllerOk.Value ?? throw new ArgumentException("NULL ERROR");
            SummonerStatsDTO summonerStats = resultLeagueControllerDynamic.GetType().GetProperty("data").GetValue(resultLeagueControllerDynamic, null);

            Assert.Equal(summonerName, summonerStats.SummonerName);
        }
    }
}
