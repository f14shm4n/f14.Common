using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace f14.Common.Tests
{
    [TestFixture]
    public class PerformanceHelperTest
    {        
        [TestCase(5, 100)]
        [TestCase(10, 100)]
        public void Do(int iterationCount, int iterationTime)
        {
            TimeSpan elapsedTime = TimeSpan.Zero;
            PerformanceHelper.Do(() =>
            {
                int counter = 0;
                while (counter++ < iterationCount)
                {
                    Thread.Sleep(iterationTime);
                }
            }, ts => elapsedTime = ts);

            Assert.True(elapsedTime.TotalMilliseconds >= iterationCount * iterationTime);
        }
                
        [TestCase(500)]
        [TestCase(1000)]
        public async Task DoAsync(int awaitMills)
        {
            TimeSpan elapsedTime = TimeSpan.Zero;
            await PerformanceHelper.DoAsync(async () => await Task.Delay(awaitMills), ts => elapsedTime = ts);

            Assert.True(elapsedTime.TotalMilliseconds >= awaitMills);
        }
    }
}
