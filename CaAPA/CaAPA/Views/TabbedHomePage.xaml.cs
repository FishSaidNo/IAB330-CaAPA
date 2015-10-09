using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

using Xamarin.Forms;

namespace CaAPA
{
	public partial class TabbedHomePage : TabbedPage
	{
		public TabbedHomePage()
		{
			BindingContext = App.Locator.TabbedHome;
			InitializeComponent();
			//base.Init();
			Title = "Home";
			//Icon =

			var myReminders = new RemindersHomePage();
			var myPrompting = new PromptingHomePage();
			var myMapping = new MappingHomePage();
			var mySettings = new SettingsHomePage();


			Children.Add(myReminders);
			Children.Add(myPrompting);
			Children.Add(myMapping);
			Children.Add(mySettings);


			//var mySettings = new NavigationPage(new SettingsHomePage());
			//var myReminders = new NavigationPage(new RemindersHomePage());
			//mySettings.Title = "Settings";
			//myReminders.Title = "Reminders";



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
			
		}
	}
}