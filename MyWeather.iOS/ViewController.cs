using System;
using MyWeather.Shared;
using UIKit;

namespace MyWeather.iOS
{
	public partial class ViewController : UIViewController
	{
		LoadingOverlay loadPop;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		async partial void CallAPIButton_TouchUpInside(UIButton sender)
		{
			var bounds = UIScreen.MainScreen.Bounds;

			// show the loading overlay on the UI thread using the correct orientation sizing
			loadPop = new LoadingOverlay(bounds); // using field from step 2
			View.Add(loadPop);

			var _api = new WeatherAPI();
			var currentWeather = await _api.GetWeather();

			UIAlertView alert = new UIAlertView()
			{
				Title = "Aviso sobre o tempo",
				Message = $"a temperatura atual é: {currentWeather.Main.Temp.ToString()}"
			};
			loadPop.Hide();
			alert.AddButton("OK");
			alert.Show();
		}
	}
}