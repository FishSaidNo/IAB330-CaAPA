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
			//Icon =

		}

		protected override void OnAppearing()
		{

		}

	}
}
