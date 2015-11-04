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
using Android.Graphics;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CaAPA.Droid.CustomTabRenderer))]

namespace CaAPA.Droid
{
	public class CustomTabRenderer : TabbedRenderer
	{
		private Activity _activity;

		//protected override void OnElementChanged(VisualElement oldModel, VisualElement newModel)
		//protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
		protected override void OnDraw(Canvas canvas)
		{
			_activity = this.Context as Activity;
			ActionBar actionBar = _activity.ActionBar;

			if (actionBar.TabCount > 0)
			{
				ActionBar.Tab tabPrompting = actionBar.GetTabAt(0);
				ActionBar.Tab tabActivities = actionBar.GetTabAt(1);
				ActionBar.Tab tabReminders = actionBar.GetTabAt(2);
				ActionBar.Tab tabMapping = actionBar.GetTabAt(3);
				ActionBar.Tab tabSettings = actionBar.GetTabAt(4);

				//Set the tab icons
				tabPrompting.SetIcon(Resource.Drawable.ic_description_white_24dp);
				tabActivities.SetIcon(Resource.Drawable.ic_description_white_24dp);
				tabReminders.SetIcon(Resource.Drawable.ic_schedule_white_24dp);
				tabMapping.SetIcon(Resource.Drawable.ic_map_white_24dp);
				tabSettings.SetIcon(Resource.Drawable.ic_settings_white_24dp);

				//Remove the page's title from the tab
				tabPrompting.SetText("");
				tabActivities.SetText("");
				tabReminders.SetText("");
				tabMapping.SetText("");
				tabSettings.SetText("");

				base.OnDraw(canvas);
			}
		}
	}
}