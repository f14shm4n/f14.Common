namespace f14.RetryPolly
{
    public class RetryPolicyInfo
    {
        public int RetryCount { get; set; } = 3;
        public int RetryDelayInMilliseconds { get; set; } = 3000;
        public RetryDelayStrategy DelayStrategy { get; set; } = RetryDelayStrategy.Linear;
    }
}
