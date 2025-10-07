using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f14.Common.Tests
{
    [TestFixture]
    public class Int32ExtensionsTest
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void GetEnumerable(int collectionSize)
        {
            var collection = collectionSize.CreateEnumerable((i, t) => (i + 1) * 2);

            collection.Should().HaveCount(collectionSize);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public async Task GetEnumerableAsync(int collectionSize)
        {
            var collection = await collectionSize.CreateEnumerableAsync((i, t) => Task.FromResult((i + 1) * 2)).ToListAsync();

            collection.Should().HaveCount(collectionSize);
        }
    }
}
