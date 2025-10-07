using FluentAssertions;

namespace f14.Common.Tests
{
    public class PaginationUtilTest
    {
        [Theory]
        [InlineData(100, 10, 10)]
        [InlineData(27, 6, 6)]
        [InlineData(1, 5, 1)]
        [InlineData(0, 4, 0)]
        public void IndexesCount(int totalItems, int indexesCount, int expectedIndexesCount)
        {
            var pagination = PaginationUtil.Calculate(totalItems, 5, 1, indexesCount);
            pagination.Indexes.Count.Should().Be(expectedIndexesCount);
        }

        [Theory]
        [InlineData(100, 17, 16)]
        [InlineData(100, 21, 19)]
        [InlineData(27, 5, 4)]
        [InlineData(27, 1, -1)]
        [InlineData(1, 1, -1)]
        [InlineData(0, -1, -1)]
        public void PrevPageIndex(int totalItems, int currentPageIndex, int expectedPrevPageIndex)
        {
            var pagination = PaginationUtil.Calculate(totalItems, 5, currentPageIndex, 7);
            pagination.Previous.Should().Be(expectedPrevPageIndex);
        }

        [Theory]
        [InlineData(100, 17, 18)]
        [InlineData(100, 21, -1)]
        [InlineData(27, 5, 6)]
        [InlineData(27, 1, 2)]
        [InlineData(1, 1, -1)]
        [InlineData(0, -1, -1)]
        public void NextPageIndex(int totalItems, int currentPageIndex, int expectedNextPageIndex)
        {
            var pagination = PaginationUtil.Calculate(totalItems, 5, currentPageIndex, 7);
            pagination.Next.Should().Be(expectedNextPageIndex);
        }
    }
}
