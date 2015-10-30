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
			//Browser.Source = "http://google.com.au";
			var rootPath = "file:///android_asset/";
			Browser.Source = new UrlWebViewSource
			{
                Url = System.IO.Path.Combine(rootPath, "mappingPage.html")
			};

		}

		protected override void OnAppearing()
		{
			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
		}

		private void backClicked(object sender, EventArgs e)
		{
			//check to see if there is anywhere to go back to
			if (Browser.CanGoBack)
			{
				Browser.GoBack();
			}
			else
			{ //if not, leave the view
				//Navigation.PopAsync();
	
			}
		}

		private void forwardClicked(object sender, EventArgs e)
		{
			if (Browser.CanGoForward)
			{
				Browser.GoForward();
			}
		}

		//void webOnNavigating(object sender, WebNavigatingEventArgs e)
		//{
		//	LoadingLabel.IsVisible = true;
		//}

		//void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
		//{
		//	LoadingLabel.IsVisible = false;
		//}
	}
}
