using System;
using System.Collections.Generic;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;
using CaAPA.Data;

namespace CaAPA
{
	public partial class ActivityHomePage : BaseView
	{
		public ActivityHomePage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.ActivityHome;


		}

		protected void ButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new AddActivityPage ());
		}

		protected override void OnAppearing ()
		{
//			base.OnAppearing ();
//			var vm = ServiceLocator.Current.GetInstance<ActivityHomeViewModel> ();
//			vm.OnAppearing ();

			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
		}
	}
}
