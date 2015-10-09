using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public partial class RemindersHomePage : BaseView
	{
		public RemindersHomePage()
		{
			BindingContext = App.Locator.RemindersHome;
			InitializeComponent();
			base.Init();
			Title = "Reminders";
			Icon = "monkeyicon.png";
		}

		protected override void OnAppearing()
		{
			//NavigationPage.SetHasBackButton(this, false);
			NavigationPage.SetTitleIcon(this, "monkeyicon.png");
			
		}

	}
}
