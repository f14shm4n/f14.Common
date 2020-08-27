using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace f14.Common.Tests
{
    [TestFixture]
    public class HttpClientExtensionsTest
    {
        [Test]
        public async Task GetAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("x-youtube-client-name", "1");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("x-youtube-client-version", "2.20190213");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36");

            var response = await httpClient.GetAsync("https://www.youtube.com/playlist?list=PLFgquLnL59an-oQxF1-GKCJ-0eWXYkOoH", null, 3, default);

            Assert.NotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
