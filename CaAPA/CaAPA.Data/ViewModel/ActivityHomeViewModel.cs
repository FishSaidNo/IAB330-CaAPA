using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace CaAPA.Data
{
	public class ActivityHomeViewModel : ViewModelBase
	{
		private const string NumberOfActivitiesKey = "NumberOfActivities";
		private const string BaseActivtiesKey = "BaseActivtiesKey";

		private IMyNavigationService navigationService;
		private ObservableCollection<Activities> activityList{ get; set;}
		public ObservableCollection<Activities> ActivityList {
			get {return activityList;}
			set{ activityList = value; 
//				RaisePropertyChanged (() => ActivityList);
			}
		}

		public ICommand NewActivityCommand { get; private set; }

		public ActivityHomeViewModel(IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
//			var database = new ActivityDatabase ();

			NewActivityCommand = new Command (() => this.navigationService.NavigateTo (ViewModelLocator.AddActivityPageKey));
		}

		public async void OnAppearing(){
			var database = new ActivityDatabase ();
//			ActivityList = new ObservableCollection<Activities> (await database.GetAll ());

			ActivityList.Add (new Activities ("Cook Dinner", "Kitchen", 1, false));
		}


	}
}

