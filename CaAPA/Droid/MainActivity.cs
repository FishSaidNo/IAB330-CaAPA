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

namespace CaAPA.Droid
{
	[Activity (Label = "CaAPA", Icon = "@drawable/awareIcon2", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			//TODO show IOC vs Dependency injection
//			SimpleIoc.Default.Register<ISqlite> (new SqliteDroid ());
			LoadApplication (new App ());

		}
	}
}

