using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace CaAPA.Data
{
	public class AddActivityViewModel : ViewModelBase
	{
		public ICommand DemoButtonCommand { get; private set; }
		public ICommand SaveAndQuit { get; private set; }
		public ICommand OpenImageSelector { get; private set; }

		private string activityName;
		public string ActivityName {
			get { return activityName; }
			set {
				activityName = value;
//				RaisePropertyChanged (() => ActivityName);
			}
		}

		private string activityLocation;
		public string ActivityLocation {
			get { return activityLocation; }
			set {
				activityLocation = value;
//				RaisePropertyChanged (() => ActivityLocation);
			}
		}
			

		public AddActivityViewModel(IMyNavigationService navigationService)
		{
			var database = new ActivityDatabase();

			DemoButtonCommand = new Command(() => {
				//create new model for adding a step
				//Do something e.g:
				//navigationService.GoBack();
				// navigationService.NavigateTo(ViewModelLocator.SamplePagePageKey);
			});

			SaveAndQuit = new Command (() => {
				database.InsertOrUpdateActivity(new Activities(ActivityName, ActivityLocation, 1, false));
				navigationService.GoBack();
			});

			OpenImageSelector = new Command(() =>
			{
				//once i get the image selecor in it'll go here
				//navigationService.NavigateTo();
				navigationService.NavigateTo(ViewModelLocator.ImagePickerPageKey);

			});
		}
	}
}