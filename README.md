# WeatherAPI

A simple and modular .NET Web API project that serves as a middleware between end users and the [OpenWeatherMap](https://openweathermap.org/) service. This project is ideal for building proof-of-concepts (POCs), testing integration strategies, or studying API consumption patterns in a clean, minimal setup.

## Features

- Exposes endpoints for:
  - **Current Weather**
  - **Weather Forecast**
- Serves as a foundation for further experimentation and feature extension
- No database or persistent storage used

## Prerequisites

- [.NET SDK 9.0+](https://dotnet.microsoft.com/download/dotnet/9.0)
- A free API key from [OpenWeatherMap](https://openweathermap.org/)

## Setup

1. Clone the repository:
   ```sh
   git clone https://github.com/steverzag/weather-api-template.git
   cd weather-api
   ```
2. Or add it to your [appsettings.json](WeatherAPI.API/appsettings.json):
    ```json
    {
        //...
        "OpenWeather": {
        "ApiKey": "<YOUR_OPEN_WEATHER_MAP_API_KEY>"
        }   
    }
    ```

3. Restore and build the project:
    ```sh
    dotnet restore
    dotnet build
    ```
## Running the Application
To run the API locally:
    ```sh
    dotnet run --project ./WeatherAPI.API/WeatherAPI.API.csproj
    ```
Or to run the application using [Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
   ```
   dotnet run --project ./WeatherAPI.AppHost/WeatherAPI.AppHost.csproj
   ```

By default, the application will be available at `http://localhost:5000` (or `https://localhost:5001` for HTTPS).

## API Usage
Example endpoints:

 - GET /current/by-city?cityName=London — Get the current weather for a city

 - GET /forecast/by-city?cityName=London — Get the weather forecast for a city

 > Refer to the included [WeatherAPI.API.http](WeatherAPI.API/WeatherAPI.API.httpWeatherAPI.API.http) file or Swagger UI for more details.





