using f14.IO;
using FluentAssertions;

namespace f14.Common.Tests
{
    public class FileIOTest
    {
        private const string StringsFilePath = "Resources/strings.txt";

        [Fact]
        public async Task ReadToEndAsync()
        {
            var content = await FileIO.ReadToEndAsync(StringsFilePath);
            List<string> lines = [.. content.Split("\n").Select(x => x.TrimEnd())];
            lines.Should().HaveCount(7);
        }

        [Fact]
        public async Task ReadLinesAsync()
        {
            List<string> lines = [];

            await foreach (var str in FileIO.ReadLinesAsync(StringsFilePath))
            {
                lines.Add(str);
            }

            lines.Should().HaveCount(7);
        }

        [Fact]
        public async Task ReadLinesAsyncWithCancellation()
        {
            var cts = new CancellationTokenSource();

            List<string> lines = [];

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

            lines.Should().HaveCount(5);
        }
    }
}
