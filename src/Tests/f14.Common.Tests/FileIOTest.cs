using f14.IO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace f14.Common.Tests
{
    [TestFixture]
    public class FileIOTest
    {
        private const string StringsFilePath = "Resources/strings.txt";

        [Test]
        public async Task ReadToEndAsync()
        {
            var content = await FileIO.ReadToEndAsync(StringsFilePath);

            List<string> lines = new List<string>(content.Split("\n").Select(x => x.TrimEnd()));

            Assert.AreEqual(7, lines.Count);
        }

        [Test]
        public async Task ReadLinesAsync()
        {
            List<string> lines = new List<string>();

            await foreach (var str in FileIO.ReadLinesAsync(StringsFilePath))
            {
                lines.Add(str);
            }

            Assert.AreEqual(7, lines.Count);
        }

        [Test]
        public async Task ReadLinesAsyncWithCancellation()
        {
            var cts = new CancellationTokenSource();

            List<string> lines = new List<string>();

            await foreach (var str in FileIO.ReadLinesAsync(StringsFilePath, cts.Token))
            {
                if (lines.Count < 5)
                {
                    lines.Add(str);
                }
                else
                {
                    cts.Cancel();
                }
            }

            Assert.AreEqual(5, lines.Count);
        }
    }
}
