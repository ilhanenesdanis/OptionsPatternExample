namespace OptionsPatternExample.Options;

public sealed class OutboxOptions
{
    public int IntervalInSeconds { get; init; }
    public int BatchSize { get; init; }
    public int RetryThresold { get; init; }
}
