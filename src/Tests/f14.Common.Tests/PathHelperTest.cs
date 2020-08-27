using f14.IO;
using NUnit.Framework;

namespace f14.Common.Tests
{
    [TestFixture]
    public class PathHelperTest
    {
        [TestCase("C:\\Temp\\logs\\sdt_1231321.txt", 1, "C:\\Temp\\logs")]
        [TestCase("C:\\Temp\\logs\\sdt_1231321.txt", 2, "C:\\Temp")]
        [TestCase("C:\\Temp/logs\\sdt_1231321.txt", 1, "C:\\Temp\\logs")]
        [TestCase("www.example.com/api/tags/list", 1, "www.example.com\\api\\tags")]
        [TestCase("www.example.com/api/tags/list", 3, "www.example.com")]
        public void RemoveSections(string path, int skip, string output)
        {
            var result = PathHelper.RemoveSections(path, skip);

            Assert.AreEqual(output, result);
        }

        [TestCase("C:\\Temp\\logs\\sdt_1231321.txt", 1, "C:/Temp/logs")]
        [TestCase("C:\\Temp\\logs\\sdt_1231321.txt", 2, "C:/Temp")]
        [TestCase("C:\\Temp/logs\\sdt_1231321.txt", 1, "C:/Temp/logs")]
        [TestCase("www.example.com/api/tags/list", 1, "www.example.com/api/tags")]
        [TestCase("www.example.com/api/tags/list", 3, "www.example.com")]
        public void RemoveAltSections(string path, int skip, string output)
        {
            var result = PathHelper.RemoveAltSections(path, skip);

            Assert.AreEqual(output, result);
        }
    }
}
