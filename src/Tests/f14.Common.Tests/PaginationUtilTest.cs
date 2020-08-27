using NUnit.Framework;

namespace f14.Common.Tests
{
    [TestFixture]
    public class PaginationUtilTest
    {
        [TestCase(100, 10, 10)]
        [TestCase(27, 6, 6)]
        [TestCase(1, 5, 1)]
        [TestCase(0, 4, 0)]
        public void IndexesCount(int totalItems, int indexesCount, int expectedIndexesCount)
        {
            var pagination = PaginationUtil.Calculate(totalItems, 5, 1, indexesCount);

            Assert.AreEqual(expectedIndexesCount, pagination.Indexes.Count);
        }

        [TestCase(100, 17, 16)]
        [TestCase(100, 21, 19)]
        [TestCase(27, 5, 4)]
        [TestCase(27, 1, -1)]
        [TestCase(1, 1, -1)]
        [TestCase(0, -1, -1)]
        public void PrevPageIndex(int totalItems, int currentPageIndex, int expectedPrevPageIndex)
        {
            var pagination = PaginationUtil.Calculate(totalItems, 5, currentPageIndex, 7);

            Assert.AreEqual(expectedPrevPageIndex, pagination.Previous);
        }    
        
        [TestCase(100, 17, 18)]
        [TestCase(100, 21, -1)]
        [TestCase(27, 5, 6)]
        [TestCase(27, 1, 2)]
        [TestCase(1, 1, -1)]
        [TestCase(0, -1, -1)]
        public void NextPageIndex(int totalItems, int currentPageIndex, int expectedNextPageIndex)
        {
            var pagination = PaginationUtil.Calculate(totalItems, 5, currentPageIndex, 7);

            Assert.AreEqual(expectedNextPageIndex, pagination.Next);
        }
    }
}
