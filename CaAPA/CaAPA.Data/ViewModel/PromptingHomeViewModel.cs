using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace CaAPA.Data
{
	public class PromptingHomeViewModel : ViewModelBase
	{
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
