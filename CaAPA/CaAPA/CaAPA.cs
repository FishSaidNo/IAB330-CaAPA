﻿using System;
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

		public App ()
		{
			
			// The root page of your application
			MainPage = GetMainPage();


		}

		public Page GetMainPage()
		{
			return new PromptingHomePage ();
//			nav = new NavigationService ();
//			nav.Configure (ViewModelLocator.NoteListPageKey, typeof(NoteListPage));
//			nav.Configure(ViewModelLocator.RemindersHomePageKey, typeof(RemindersHomePage));
//			nav.Configure(ViewModelLocator.ReminderEntryPageKey, typeof(ReminderEntryPage));
//            nav.Configure(ViewModelLocator.PromptingHomePageKey, typeof(PromptingHomePage));
//			nav.Configure(ViewModelLocator.MappingHomePageKey, typeof(MappingHomePage));
//			nav.Configure(ViewModelLocator.SettingsHomePageKey, typeof(SettingsHomePage));
//			nav.Configure(ViewModelLocator.TabbedHomePageKey, typeof(TabbedHomePage));
//
//			SimpleIoc.Default.Register<IMyNavigationService> (()=> nav, true);
//			var navPage = new NavigationPage(new TabbedHomePage());
//			nav.Initialize(navPage);
//			return navPage;
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

