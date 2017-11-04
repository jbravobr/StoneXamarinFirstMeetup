using Android.App;
using Android.Widget;
using Android.OS;
using MyWeather.Shared;
using Android.Support.V7.App;
using System;

namespace MyWeather.Droid
{
	[Activity(Label = "MyWeather.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : ActionBarActivity
	{
		int count = 1;
		Android.App.ProgressDialog progress;

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
				progress = new ProgressDialog(this)
				{
					Indeterminate = true
				};
				progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
				progress.SetMessage("Carregando informações do tempo...");
				progress.SetCancelable(false);
				progress.Show();

				var _api = new WeatherAPI();
				var currentWeather = await _api.GetWeather();

				Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);

				progress.Dismiss();
				alert.SetTitle("Aviso sobre o tempo");
				alert.SetMessage($"a temperatura atual é: {Math.Round(currentWeather.TempInCelsius, 0).ToString()}");
				alert.SetPositiveButton("OK", (sender, e) => { });

				Dialog dialog = alert.Create();
				dialog.Show();
			};
		}
	}
}

