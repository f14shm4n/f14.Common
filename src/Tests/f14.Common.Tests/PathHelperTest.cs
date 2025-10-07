using f14.IO;
using FluentAssertions;

namespace f14.Common.Tests
{
    public class PathHelperTest
    {
        [Theory]
        [InlineData("C:\\Temp\\logs\\sdt_1231321.txt", 1, "C:\\Temp\\logs")]
        [InlineData("C:\\Temp\\logs\\sdt_1231321.txt", 2, "C:\\Temp")]
        [InlineData("C:\\Temp/logs\\sdt_1231321.txt", 1, "C:\\Temp\\logs")]
        [InlineData("www.example.com/api/tags/list", 1, "www.example.com\\api\\tags")]
        [InlineData("www.example.com/api/tags/list", 3, "www.example.com")]
        public void RemoveSections(string path, int skip, string output)
        {
            var result = PathHelper.RemoveSections(path, skip);
            result.Should().Be(output);
        }

        [Theory]
        [InlineData("C:\\Temp\\logs\\sdt_1231321.txt", 1, "C:/Temp/logs")]
        [InlineData("C:\\Temp\\logs\\sdt_1231321.txt", 2, "C:/Temp")]
        [InlineData("C:\\Temp/logs\\sdt_1231321.txt", 1, "C:/Temp/logs")]
        [InlineData("www.example.com/api/tags/list", 1, "www.example.com/api/tags")]
        [InlineData("www.example.com/api/tags/list", 3, "www.example.com")]
        public void RemoveAltSections(string path, int skip, string output)
        {
            var result = PathHelper.RemoveAltSections(path, skip);
            result.Should().Be(output);
        }
    }
}
