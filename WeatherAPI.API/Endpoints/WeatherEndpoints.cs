using WeatherAPI.API.DTOs;
using WeatherAPI.API.Endpoints.Configuration;
using WeatherAPI.API.Services;

namespace WeatherAPI.API.Endpoints
{
	public class WeatherEndpoints : IEndpoints
	{
		public void RegisterEndpoints(IEndpointRouteBuilder builder)
		{
			builder.MapGet("/current", GetCurrentWeatherByCoordinates);
			builder.MapGet("/current/by-city", GetCurrentWeatherByCity);
			builder.MapGet("/forecast", GetForecastByCoordinates);
			builder.MapGet("/forecast/by-city", GetForecastByCity);
		}

		public static async Task<IResult> GetCurrentWeatherByCity(WeatherService weatherService, string cityName, string? stateCode = null, string? countryCode = null, string? units = null)
		{
			var request = new WeatherByCityRequestDTO
			{
				City = cityName,
				StateCode = stateCode,
				CountryCode = countryCode,
				Units = units
			};

			var response = await weatherService.GetCurrentWeatherByCityAsync(request);
			if (response == null)
			{
				return Results.NotFound();
			}

			return Results.Ok(response);
		}

		public static async Task<IResult> GetCurrentWeatherByCoordinates(WeatherService weatherService, double lon, double lat, string? units = null)
		{
			var request = new WeatherByCoordinatesRequestDTO
			{
				Longitude = lon,
				Latitude = lat,
				Units = units
			};

			var response = await weatherService.GetCurrentWeatherByCoordinatesAsync(request);
			if (response == null)
			{
				return Results.NotFound();
			}

			return Results.Ok(response);
		}

		public static async Task<IResult> GetForecastByCity(WeatherService weatherService, string cityName, string? stateCode = null, string? countryCode = null, string? units = null)
		{
			var request = new WeatherByCityRequestDTO
			{
				City = cityName,
				StateCode = stateCode,
				CountryCode = countryCode,
				Units = units
			};

			var response = await weatherService.GetForecastByCityAsync(request);
			if (response == null)
			{
				return Results.NotFound();
			}

			return Results.Ok(response);
		}

		public static async Task<IResult> GetForecastByCoordinates(WeatherService weatherService, double lon, double lat, string? units = null)
		{
			var request = new WeatherByCoordinatesRequestDTO
			{
				Longitude = lon,
				Latitude = lat,
				Units = units
			};

			var response = await weatherService.GetForecastByCoordinatesAsync(request);
			if (response == null)
			{
				return Results.NotFound();
			}

			return Results.Ok(response);
		}
	}
}
