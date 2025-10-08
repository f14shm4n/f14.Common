namespace f14.RetryPolly
{
    public static class RetryPolicyExtensions
    {
        public static TimeSpan CalculateDelay(this RetryPolicyInfo source, int retryAttempt)
        {
            ArgumentNullException.ThrowIfNull(source);

            return source.DelayStrategy switch
            {
                // Linear
                _ => TimeSpan.FromMilliseconds(source.RetryDelayInMilliseconds * retryAttempt),
            };
        }
    }
}
