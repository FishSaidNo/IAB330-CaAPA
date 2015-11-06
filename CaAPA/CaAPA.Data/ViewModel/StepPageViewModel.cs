using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace CaAPA.Data
{
	public class StepPageViewModel :ViewModelBase
	{
		public ICommand ButtonCommand { get; private set; }

		public StepPageViewModel(IMyNavigationService navigationService)
		{
			ButtonCommand = new Command(() =>
				{
					//do something neat here
				});
		}
	}
}