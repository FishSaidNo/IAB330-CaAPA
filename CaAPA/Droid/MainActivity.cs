using System;

using Android.App;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using AltBeaconOrg.BoundBeacon;
using CaAPA.Data;
using AltBeaconOrg.BoundBeacon;

namespace CaAPA.Droid
{
<<<<<<< HEAD
	[Activity(Label = "CaAPa",
		Icon = "@drawable/monkeyicon",
		MainLauncher = true,
		LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
	public class MainActivity : FormsApplicationActivity, IBeaconConsumer
	{
		protected override void OnCreate(Bundle savedInstanceState)
=======
	[Activity (Label = "CaAPA", Icon = "@drawable/awareIcon2", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleInstance, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, IBeaconConsumer
	{
		private Action<int, Result, Intent> _activityResultCallBack;

		protected override void OnCreate (Bundle bundle)
>>>>>>> jonathan-30-10
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
<<<<<<< HEAD
		#endregion
=======

		#region IBeaconConsumer Implementation
		public void OnBeaconServiceConnect()
		{
			var beaconService = Xamarin.Forms.DependencyService.Get<IAltBeaconService>();
			beaconService.StartMonitoring();
			beaconService.StartRanging();

		}
		#endregion

		public void ConfigureActivityResultCallBack(Action<int, Result, Intent> callback)
		{
			if (callback == null)
				throw new ArgumentNullException("callback");
			_activityResultCallBack = callback;
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (_activityResultCallBack != null)
			{
				_activityResultCallBack.Invoke(requestCode, resultCode, data);
				_activityResultCallBack = null;
			}
		}
>>>>>>> jonathan-30-10
	}
}

