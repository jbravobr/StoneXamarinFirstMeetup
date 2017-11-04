using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace MyWeather
{
	public partial class CurrentWeather
	{
		[JsonProperty("coord")]
		public Coord Coord { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("clouds")]
		public Clouds Clouds { get; set; }

		[JsonProperty("base")]
		public string Base { get; set; }

		[JsonIgnore]
		public double TempInCelsius
		{
			get
			{
				var celsius = Main.Temp - 273.15;
				return celsius;
			}
		}

		[JsonProperty("cod")]
		public long Cod { get; set; }

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("dt")]
		public long Dt { get; set; }

		[JsonProperty("main")]
		public Main Main { get; set; }

		[JsonProperty("visibility")]
		public long Visibility { get; set; }

		[JsonProperty("sys")]
		public Sys Sys { get; set; }

		[JsonProperty("weather")]
		public List<Weather> Weather { get; set; }

		[JsonProperty("wind")]
		public Wind Wind { get; set; }
	}

	public partial class Coord
	{
		[JsonProperty("lat")]
		public double Lat { get; set; }

		[JsonProperty("lon")]
		public double Lon { get; set; }
	}

	public partial class Clouds
	{
		[JsonProperty("all")]
		public long All { get; set; }
	}

	public partial class Main
	{
		[JsonProperty("pressure")]
		public long Pressure { get; set; }

		[JsonProperty("temp_max")]
		public double TempMax { get; set; }

		[JsonProperty("humidity")]
		public long Humidity { get; set; }

		[JsonProperty("temp")]
		public double Temp { get; set; }

		[JsonProperty("temp_min")]
		public double TempMin { get; set; }
	}

	public partial class Sys
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("sunrise")]
		public long Sunrise { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("message")]
		public double Message { get; set; }

		[JsonProperty("sunset")]
		public long Sunset { get; set; }

		[JsonProperty("type")]
		public long Type { get; set; }
	}

	public partial class Weather
	{
		[JsonProperty("icon")]
		public string Icon { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("main")]
		public string Main { get; set; }
	}

	public partial class Wind
	{
		[JsonProperty("deg")]
		public long Deg { get; set; }

		[JsonProperty("speed")]
		public double Speed { get; set; }
	}

	public partial class CurrentWeather
	{
		public static CurrentWeather FromJson(string json) => JsonConvert.DeserializeObject<CurrentWeather>(json, Converter.Settings);
	}

	public static class Serialize
	{
		public static string ToJson(this CurrentWeather self) => JsonConvert.SerializeObject(self, Converter.Settings);
	}

	public class Converter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
		};
	}
}