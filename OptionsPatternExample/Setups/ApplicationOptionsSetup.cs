using Microsoft.Extensions.Options;
using OptionsPatternExample.Options;

namespace OptionsPatternExample.Setup;

public sealed class ApplicationOptionsSetup : IConfigureOptions<ApplicationOptions>
{
    private readonly IConfiguration _configuration;

    public ApplicationOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ApplicationOptions options)
    {
        _configuration.GetSection(nameof(ApplicationOptions)).Bind(options);
    }
}
