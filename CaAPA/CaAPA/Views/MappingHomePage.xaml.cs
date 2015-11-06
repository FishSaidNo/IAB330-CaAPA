using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public partial class MappingHomePage : BaseView
	{
		public MappingHomePage()
		{
			BindingContext = App.Locator.MappingHome;
			InitializeComponent();
			base.Init();
			Title = "Mapping";
			BackgroundColor = Color.FromRgb(255, 255, 255);


			var rootPath = "file:///android_asset/"; //Root path for the webview contents
			Browser.Source = new UrlWebViewSource
			{
				//All the mapping functionality is provided via javascript/html/css
				//Located in the Android assets directory
                Url = System.IO.Path.Combine(rootPath, "mappingPage.html")
			};
//			GC.Collect ();

			//Force our Browser to open links in the device's external browser
			Browser.Navigating += (s, e) =>
			{
				if (e.Url.StartsWith("http"))
				{
					try
					{
						var uri = new Uri(e.Url);
						Device.OpenUri(uri);
					}
					catch (Exception)
					{
						//
					}

					e.Cancel = true;
				}
			};

		} //End constructor

		protected override void OnAppearing()
		{
			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
		}

	} //End class
} //End namespace
