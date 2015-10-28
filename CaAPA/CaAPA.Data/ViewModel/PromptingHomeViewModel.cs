using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;

namespace CaAPA.Data
{
	public class PromptingHomeViewModel : ViewModelBase
	{
        /*public ObservableCollection<Activity> Activities
        {
           get
            {
                var database = new ActivityDatabase();
                var x = database.GetAllActivities();
                return new ObservableCollection<Activity>(x);
            }
        }*/
		public ICommand DemoButtonCommand { get; private set; }

		public PromptingHomeViewModel(IMyNavigationService navigationService)
		{

			DemoButtonCommand = new Command(() => {
				//Do something e.g:
				//navigationService.GoBack();
				navigationService.NavigateTo(ViewModelLocator.SamplePagePageKey);
			});

		}

	}
}
