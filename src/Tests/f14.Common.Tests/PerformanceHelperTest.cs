using FluentAssertions;

namespace f14.Common.Tests
{
    public class PerformanceHelperTest
    {
        [Theory]
        [InlineData(5, 100)]
        [InlineData(10, 100)]
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

            (elapsedTime.TotalMilliseconds >= iterationCount * iterationTime).Should().BeTrue();
        }

        [Theory]
        [InlineData(500)]
        [InlineData(1000)]
        public async Task DoAsync(int awaitMills)
        {
            TimeSpan elapsedTime = TimeSpan.Zero;
            await PerformanceHelper.DoAsync(async () => await Task.Delay(awaitMills), ts => elapsedTime = ts);

            (elapsedTime.TotalMilliseconds >= awaitMills).Should().BeTrue();
        }
    }
}
