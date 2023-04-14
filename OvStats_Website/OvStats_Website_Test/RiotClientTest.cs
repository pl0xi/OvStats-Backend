using Moq;
using OvStats_Website.Clients;
using OvStats_Website.DTO;

namespace OvStats_Website_Test
{
    public class RiotClientTest
    {
        private readonly IRiotClient _IRiotClient;

        public RiotClientTest()
        {
            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            _IRiotClient = new RiotClient(mockHttpClient.Object);
        }

        [Fact]
        public async Task GetAccountTestAsync()
        {
            string username = "sofieee";
            string region = "euw1";
            SummonerAccountDTO summonerAccountDTO = await _IRiotClient.GetAccount(username, region);

            Assert.NotNull(summonerAccountDTO.id);
            Assert.Equal("sofieee", summonerAccountDTO.name);
        }
    }
}