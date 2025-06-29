using Microsoft.AspNetCore.WebUtilities;
using System;
using WeatherAPI.API.Endpoints.Configuration;
using WeatherAPI.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHttpClient<WeatherService>(client =>
{
	client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.Run();