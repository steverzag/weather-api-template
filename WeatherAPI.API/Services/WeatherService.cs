using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using WeatherAPI.API.DTOs;
using WeatherAPI.API.External;
using WeatherAPI.API.Mapping;

namespace WeatherAPI.API.Services
{
	public class WeatherService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _openWeatherApiKey;
		private const string _openWeatherApiVersion = "2.5";

		public WeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_openWeatherApiKey = configuration["OpenWeather:ApiKey"] ?? throw new NullReferenceException(nameof(_openWeatherApiKey));
		}

		public async Task<CurrentWeatherResponse?> GetCurrentWeatherByCityAsync(WeatherByCityRequestDTO request)
		{
			if(string.IsNullOrEmpty(request.City))
			{
				return null;
			}
			var url = $"https://api.openweathermap.org/data/{_openWeatherApiVersion}/weather";
			var queryParams = new Dictionary<string, string?>();

			var qParam = request.City;

			if (!string.IsNullOrEmpty(request.StateCode))
			{
				qParam += $",{request.StateCode}";
			}
			if (!string.IsNullOrEmpty(request.CountryCode))
			{
				qParam += $",{request.CountryCode}";
			}
			
			queryParams.Add("q", qParam);

			var degreeUnits = request.Units switch
			{
				"f" => "imperial",
				"k" => "standard",
				_ => "metric"
			};
			
			queryParams.Add("units", degreeUnits);
			queryParams.Add("appid", _openWeatherApiKey);

			QueryHelpers.AddQueryString(url, queryParams);

			var uri = new Uri(QueryHelpers.AddQueryString(url, queryParams));

			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync(uri);
			if (response.StatusCode is HttpStatusCode.NotFound)
			{
				return null;
			}

			var openWeatherResponse = await response.Content.ReadFromJsonAsync<OpenWeatherResponse>();
			return openWeatherResponse?.MapToCurrentWeatherResponse(request.Units ?? "c") ?? null;
		}

		public async Task<CurrentWeatherResponse?> GetCurrentWeatherByCoordinatesAsync(WeatherByCoordinatesRequestDTO request)
		{
			var url = $"https://api.openweathermap.org/data/{_openWeatherApiVersion}/weather?lat={request.Latitude}&lon={request.Longitude}";
			var queryParams = new Dictionary<string, string?>();

			var degreeUnits = request.Units switch
			{
				"f" => "imperial",
				"k" => "standard",
				_ => "metric"
			};

			queryParams.Add("units", degreeUnits);
			queryParams.Add("appid", _openWeatherApiKey);

			QueryHelpers.AddQueryString(url, queryParams);

			var uri = new Uri(QueryHelpers.AddQueryString(url, queryParams));

			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync(uri);
			if (response.StatusCode is HttpStatusCode.NotFound)
			{
				return null;
			}

			var openWeatherResponse = await response.Content.ReadFromJsonAsync<OpenWeatherResponse>();
			return openWeatherResponse?.MapToCurrentWeatherResponse(request.Units ?? "c") ?? null;
		}

		public async Task<ForecastResponse?> GetForecastByCityAsync(WeatherByCityRequestDTO request)
		{
			if (string.IsNullOrEmpty(request.City))
			{
				return null;
			}
			var url = $"https://api.openweathermap.org/data/{_openWeatherApiVersion}/forecast";
			var queryParams = new Dictionary<string, string?>();

			var qParam = request.City;

			if (!string.IsNullOrEmpty(request.StateCode))
			{
				qParam += $",{request.StateCode}";
			}
			if (!string.IsNullOrEmpty(request.CountryCode))
			{
				qParam += $",{request.CountryCode}";
			}

			queryParams.Add("q", qParam);

			var degreeUnits = request.Units switch
			{
				"f" => "imperial",
				"k" => "standard",
				_ => "metric"
			};

			queryParams.Add("units", degreeUnits);
			queryParams.Add("appid", _openWeatherApiKey);

			QueryHelpers.AddQueryString(url, queryParams);

			var uri = new Uri(QueryHelpers.AddQueryString(url, queryParams));

			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync(uri);
			if (response.StatusCode is HttpStatusCode.NotFound)
			{
				return null;
			}

			var openWeatherForecastResponse = await response.Content.ReadFromJsonAsync<OpenWeatherForecastResponse>();
			return openWeatherForecastResponse?.MapToForecastResponse(request.Units ?? "c") ?? null;
		}

		public async Task<ForecastResponse?> GetForecastByCoordinatesAsync(WeatherByCoordinatesRequestDTO request)
		{
			var url = $"https://api.openweathermap.org/data/{_openWeatherApiVersion}/forecast?lat={request.Latitude}&lon={request.Longitude}";
			var queryParams = new Dictionary<string, string?>();

			var degreeUnits = request.Units switch
			{
				"f" => "imperial",
				"k" => "standard",
				_ => "metric"
			};

			queryParams.Add("units", degreeUnits);
			queryParams.Add("appid", _openWeatherApiKey);

			QueryHelpers.AddQueryString(url, queryParams);

			var uri = new Uri(QueryHelpers.AddQueryString(url, queryParams));

			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync(uri);
			if (response.StatusCode is HttpStatusCode.NotFound)
			{
				return null;
			}

			var openWeatherForecastResponse = await response.Content.ReadFromJsonAsync<OpenWeatherForecastResponse>();
			return openWeatherForecastResponse?.MapToForecastResponse(request.Units ?? "c") ?? null;
		}
	}
}
