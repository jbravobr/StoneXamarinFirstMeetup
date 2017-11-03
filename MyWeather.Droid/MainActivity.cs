using Android.App;
using Android.Widget;
using Android.OS;
using MyWeather.Shared;

namespace MyWeather.Droid
{
	[Activity(Label = "MyWeather.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += async delegate
			{
				var _api = new WeatherAPI();
				var currentWeather = await _api.GetWeather();

				AlertDialog.Builder alert = new AlertDialog.Builder(this);
				alert.SetTitle("Aviso sobre o tempo");
				alert.SetMessage($"a temperatura atual é: {currentWeather.Main.Temp.ToString()}");
				alert.SetPositiveButton("OK", (sender, e) => { });

				Dialog dialog = alert.Create();
				dialog.Show();
			};
		}
	}
}

