using System;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public class App : Application
	{
		private static ViewModelLocator _locator;
		private static NavigationService nav;
		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}
		
		private const string TextToSpeechSpeedKey = "TextToSpeechSpeed";
		private const string TextToSpeechEnableKey = "TextToSpeechEnable";
		private const string CloudSyncEnableKey = "CloudSyncEnable";
		private const string BackgroundColourKey = "BackgroundColour";

		public App ()
		{
			
			Color temp = Color.White;
			//tts toggle
			if (!Application.Current.Properties.ContainsKey (TextToSpeechEnableKey)) {
				Application.Current.Properties.Add (TextToSpeechEnableKey, false);
			}
			//tts speed setting
			if (!Application.Current.Properties.ContainsKey (TextToSpeechSpeedKey)) {
				Application.Current.Properties.Add (TextToSpeechSpeedKey, 1.0f);
			} else
				Application.Current.Properties [TextToSpeechSpeedKey] = 1.0f;
			//cloud sync key
			if(!Application.Current.Properties.ContainsKey(CloudSyncEnableKey)){
				Application.Current.Properties.Add (CloudSyncEnableKey, true);
			}
			//background colour key
			if (!Application.Current.Properties.ContainsKey (BackgroundColourKey)) {
				Application.Current.Properties.Add(BackgroundColourKey, temp);
			}
			
			
			// The root page of your application
			MainPage = GetMainPage();


		}

		public Page GetMainPage()
		{
			nav = new NavigationService ();
			nav.Configure(ViewModelLocator.TabbedHomePageKey, typeof(TabbedHomePage));
			nav.Configure (ViewModelLocator.NoteListPageKey, typeof(NoteListPage));
			nav.Configure(ViewModelLocator.RemindersHomePageKey, typeof(RemindersHomePage));
			nav.Configure(ViewModelLocator.PromptingHomePageKey, typeof(PromptingHomePage));
			nav.Configure(ViewModelLocator.MappingHomePageKey, typeof(MappingHomePage));
			nav.Configure(ViewModelLocator.SettingsHomePageKey, typeof(SettingsHomePage));
			nav.Configure(ViewModelLocator.TabbedHomePageKey, typeof(TabbedHomePage));
			nav.Configure(ViewModelLocator.SamplePagePageKey, typeof(SamplePage));
			nav.Configure(ViewModelLocator.AddActivityPageKey, typeof(AddActivityPage));
			nav.Configure(ViewModelLocator.ImagePickerPageKey, typeof(ImagePickerPage));
			nav.Configure(ViewModelLocator.AddReminderPageKey, typeof(AddReminderPage));
			nav.Configure(ViewModelLocator.StepPageKey, typeof(StepPage));

			SimpleIoc.Default.Register<IMyNavigationService> (()=> nav, true);
			var navPage = new NavigationPage(new TabbedHomePage());
			nav.Initialize(navPage);
			return navPage;
		}
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

