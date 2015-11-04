using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public partial class TabbedHomePage : TabbedPage
	{
		public TabbedHomePage()
		{
			BindingContext = App.Locator.TabbedHome;
			InitializeComponent();
//			base.Init();
			Title = "Home"; //Shouldn't be displayed.
			BackgroundColor = Color.FromRgb(255,255,255);

			var myPrompting = new ActivityHomePage();
			var myReminders = new RemindersHomePage();
			var myMapping = new MappingHomePage();
			var mySettings = new SettingsHomePage();

			Children.Add(myPrompting);
			Children.Add(myReminders);
			Children.Add(myMapping);
			Children.Add(mySettings);
		}

		protected void Init()
		{

			var lifecycleHandler = this.BindingContext as IPageLifeCycleEvents;

			if (lifecycleHandler != null)
			{
				base.Appearing += (object sender, EventArgs e) => {
					lifecycleHandler.OnAppearing();
				};
				base.Disappearing += (object sender, EventArgs e) => {
					lifecycleHandler.OnDisappearing();
				};
				base.LayoutChanged += (object sender, EventArgs e) => {
					lifecycleHandler.OnLayoutChanged();
				};
			}
		}

		protected override void OnAppearing()
		{
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}