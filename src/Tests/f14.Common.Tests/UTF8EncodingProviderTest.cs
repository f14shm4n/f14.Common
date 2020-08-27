using NUnit.Framework;
using System.Text;

namespace f14.Common.Tests
{
    [TestFixture]
    public class UTF8EncodingProviderTest
    {
        [TestCase("utf8")]
        [TestCase("UTF8")]
        [TestCase("\"UTF8\"")]
        [TestCase("\"utf-8\"")]
        [TestCase("\"UTF-8\"")]
        public void GetEncodingByEncodingName(string encodingName)
        {
            var encodingProvider = new UTF8EncodingProvider();
            var encoding = encodingProvider.GetEncoding(encodingName);

            Assert.NotNull(encoding);
        }
    }
}