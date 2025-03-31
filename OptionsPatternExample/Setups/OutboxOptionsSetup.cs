using Microsoft.Extensions.Options;
using OptionsPatternExample.Options;

namespace OptionsPatternExample.Setups;

public sealed class OutboxOptionsSetup : IConfigureOptions<OutboxOptions>
{
    private readonly IConfiguration _configuration;

    public OutboxOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(OutboxOptions options)
    {
        _configuration.GetSection(nameof(OutboxOptions)).Bind(options);
    }
}
