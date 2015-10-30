using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Ioc;
using CaAPA.Data;
using AltBeaconOrg.BoundBeacon;

namespace CaAPA.Droid
{
	[Activity (Label = "CaAPA", Icon = "@drawable/awareIcon2", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleInstance, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, IBeaconConsumer
	{
		private Action<int, Result, Intent> _activityResultCallBack;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			//TODO show IOC vs Dependency injection
//			SimpleIoc.Default.Register<ISqlite> (new SqliteDroid ());
			LoadApplication (new App ());

		}

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
	}
}

