using Microsoft.Extensions.Options;
using OptionsPatternExample.Options;
using OptionsPatternExample.Setup;
using OptionsPatternExample.Setups;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();


builder.Services.ConfigureOptions<ApplicationOptionsSetup>();
builder.Services.ConfigureOptions<OutboxOptionsSetup>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("options", (IOptions<ApplicationOptions> options,
                       IOptionsSnapshot<ApplicationOptions> optionsSnapshot,
                       IOptionsMonitor<ApplicationOptions> optionsMonitor) =>
{
    var response = new
    {
        OptionsValue = options.Value.ExampleValue,
        SnapshotValue = optionsSnapshot.Value.ExampleValue,
        MonitorValue = optionsMonitor.CurrentValue.ExampleValue
    };

    return Results.Ok(response);
});

app.Run();
