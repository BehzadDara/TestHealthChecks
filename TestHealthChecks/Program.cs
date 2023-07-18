using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using TestHealthChecks;

var services = new ServiceCollection();

services.AddHealthChecks()
    .AddCheck<ExampleCheck>(tags: new[] { "Service" }, name: "Example Check");
services.AddSingleton(typeof(IHealthCheck), typeof(ExampleCheck));

var serviceProvider = services.BuildServiceProvider();
var healthCheckService = serviceProvider.GetService<IHealthCheck>();

var result = await healthCheckService!.CheckHealthAsync(new());

var options = new JsonSerializerOptions
{
    WriteIndented = true,
    Converters = { new StatusConverter() }
};
var jsonResult = JsonSerializer.Serialize(result, options);

Console.WriteLine(jsonResult);
Console.ReadKey();