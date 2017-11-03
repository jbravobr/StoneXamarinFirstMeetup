using System;
using Xunit;

using MyWeather.Shared;

namespace MyWeather.Test
{
	public class WeatherAPITest
	{
		[Fact]
		public async void Call_API_And_Return_Weather()
		{
			var api = new WeatherAPI();
			var weather = await api.GetWeather();

			Assert.NotNull(weather);
		}
	}
}
