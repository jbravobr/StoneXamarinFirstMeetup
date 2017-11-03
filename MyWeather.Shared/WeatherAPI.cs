using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyWeather.Shared
{
	public class WeatherAPI
	{
		/// <summary>
		/// The API key.
		/// </summary>
		private string API_KEY = "23ffbb663d51b9537a163e0323c012bc";

		/// <summary>
		/// The city identifier.
		/// </summary>
		private int CityId = 3451190;

		/// <summary>
		/// The weather.
		/// </summary>
		CurrentWeather weather;

		/// <summary>
		/// Gets the weather.
		/// </summary>
		/// <returns>The weather.</returns>
		public async Task<CurrentWeather> GetWeather()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri($"http://api.openweathermap.org/data/2.5/weather");

				try
				{
					var json = await client.GetAsync($"?id={CityId}&APPID={API_KEY}&lang=pt");
					var content = await json.Content.ReadAsStringAsync();

					if (string.IsNullOrWhiteSpace(content))
						throw new ArgumentNullException(nameof(json), "Erro ao coletar informações do tempo.");

					weather = CurrentWeather.FromJson(content);
					return weather;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
	}
}
