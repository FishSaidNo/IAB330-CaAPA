using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace CaAPA.Data
{
	public class MappingHomeViewModel : ViewModelBase
	{
		public ICommand DemoButtonCommand { get; private set; }

		public MappingHomeViewModel(IMyNavigationService navigationService)
		{

			DemoButtonCommand = new Command(() => {
				//Do something e.g:
				//navigationService.GoBack();
				navigationService.NavigateTo(ViewModelLocator.SamplePagePageKey);
			});

		}

	}
}
