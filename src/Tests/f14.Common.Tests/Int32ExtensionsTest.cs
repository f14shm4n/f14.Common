using FluentAssertions;

namespace f14.Common.Tests
{
    public class Int32ExtensionsTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        public void GetEnumerable(int collectionSize)
        {
            var collection = collectionSize.CreateEnumerable((i, t) => (i + 1) * 2);
            collection.Should().HaveCount(collectionSize);
        }
    }
}
