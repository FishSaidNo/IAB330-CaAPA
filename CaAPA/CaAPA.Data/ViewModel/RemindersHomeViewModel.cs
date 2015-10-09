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
		public ICommand DemoButtonCommand { get; private set; }

		public RemindersHomeViewModel(IMyNavigationService navigationService)
		{

			DemoButtonCommand = new Command(() => {
				//Do something e.g:
				//navigationService.GoBack();
				
			});

		}

	}
}
