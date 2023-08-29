//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;

namespace BlazorGrpc.Shared
{
	
	
	public class WeatherService : BlazorGrpc.Shared.WeatherForecastService.WeatherForecastServiceBase
	{
		private static readonly string[] Summaries = new[]
		{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

		public override Task<WeatherForecastResponse> GetWeatherForecast(Empty request, ServerCallContext context)
		{
			var reply = new WeatherForecastResponse();
		//	reply.Forecasts.AddRange(GetWeatherForecast(Empty request, ServerCallContext context));
			var rng = new Random();

			reply.Forecasts.Add(Enumerable.Range(1, 10).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			}));

			return Task.FromResult(reply);
		}
	}
}
