var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WeatherAPI_API>("weatherapi-api");

builder.Build().Run();
