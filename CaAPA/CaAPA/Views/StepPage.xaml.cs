using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public partial class StepPage : BaseView
	{
		public StepPage()
		{
			BindingContext = App.Locator.Step;
			InitializeComponent();
			base.Init();
			Title = "Step";
			BackgroundColor = Color.White;

		}
		protected override void OnAppearing()
		{
			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
		}
		private void goforwadstep(object sender, EventArgs e)
		{
			//check if this step is last
			//load next step in this same view
		}

		private void gobackstep(object sender, EventArgs e)
		{
			//if step is first return us to main view we launched from
			//load previous step in same view
			//activity.decrement step
		}
	}
}