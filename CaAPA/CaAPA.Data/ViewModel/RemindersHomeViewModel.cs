using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;
using CaAPA;
using System.Diagnostics;

namespace CaAPA.Data
{
	public class RemindersHomeViewModel : ViewModelBase
	{
		public ICommand AddNewReminderCommand { get; private set; }

		public RemindersHomeViewModel(IMyNavigationService navigationService)
		{

			AddNewReminderCommand = new Command(() => {
				//Do something e.g:
				//navigationService.GoBack();
				navigationService.NavigateTo(ViewModelLocator.AddReminderPageKey);
			});

		}

	}
}
