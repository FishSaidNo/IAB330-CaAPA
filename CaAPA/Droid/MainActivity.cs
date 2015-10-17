using System;

using Android.App;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using AltBeaconOrg.BoundBeacon;
using CaAPA.Data;

namespace CaAPA.Droid
{
	[Activity(Label = "CaAPa",
		Icon = "@drawable/monkeyicon",
		MainLauncher = true,
		LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
	public class MainActivity : FormsApplicationActivity, IBeaconConsumer
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Xamarin.Forms.Forms.Init(this, savedInstanceState);

			LoadApplication(new App());
		}

		#region IBeaconConsumer Implementation
		public void OnBeaconServiceConnect()
		{
			var beaconService = Xamarin.Forms.DependencyService.Get<IAltBeaconService>();

			beaconService.StartMonitoring();
			beaconService.StartRanging();
		}
		#endregion
	}
}

