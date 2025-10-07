using FluentAssertions;
using System.Text;

namespace f14.Common.Tests
{
    public class UTF8EncodingProviderTest
    {
        [Theory]
        [InlineData("utf8")]
        [InlineData("UTF8")]
        [InlineData("\"UTF8\"")]
        [InlineData("\"utf-8\"")]
        [InlineData("\"UTF-8\"")]
        public void GetEncodingByEncodingName(string encodingName)
        {
            var encodingProvider = new UTF8EncodingProvider();
            var encoding = encodingProvider.GetEncoding(encodingName);
            encoding.Should().NotBeNull();
        }
    }
}