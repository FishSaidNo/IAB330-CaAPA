using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CaAPA.Droid.CustomTabRenderer))]

namespace CaAPA.Droid
{
	public class CustomTabRenderer : TabbedRenderer
	{
		private Activity _activity;

		//protected override void OnElementChanged(VisualElement oldModel, VisualElement newModel)
		protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
		{
			base.OnElementChanged(e);

			_activity = this.Context as Activity;
		}

		// May put this code in a different method - was just for testing
		public override void OnWindowFocusChanged(bool hasWindowFocus)
		{
			// Here the magic happens:  get your ActionBar and select the tab you want to add an image
			ActionBar actionBar = _activity.ActionBar;

			if (actionBar.TabCount > 0)
			{
				Android.App.ActionBar.Tab tabOne = actionBar.GetTabAt(0);

				tabOne.SetIcon(Resource.Drawable.monkeyicon);
			}
			base.OnWindowFocusChanged(hasWindowFocus);
		}
	}
}