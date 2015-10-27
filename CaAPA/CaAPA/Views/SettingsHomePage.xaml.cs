using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public partial class SettingsHomePage : BaseView
	{
		public SettingsHomePage()
		{
			BindingContext = App.Locator.SettingsHome;
			InitializeComponent();
			base.Init();
			Title = "Settings";
			BackgroundColor = Color.FromRgb(255, 255, 255);
		}

		protected override void OnAppearing()
		{
			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
		}

	}
}
