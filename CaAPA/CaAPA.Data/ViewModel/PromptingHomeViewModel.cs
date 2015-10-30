//using System;
//using GalaSoft.MvvmLight;
//using System.Windows.Input;
//using Xamarin.Forms;
//using CaAPA.Data.ViewModel;
//using Microsoft.Practices.ServiceLocation;

using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
<<<<<<< HEAD
using System.Collections.Generic;
using GalaSoft.MvvmLight;
=======
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Diagnostics;
>>>>>>> jonathan-30-10

namespace CaAPA.Data
{
	public class PromptingHomeViewModel : ViewModelBase
	{
<<<<<<< HEAD
		private IMyNavigationService navigationService;

		public PromptingHomeViewModel(IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			Data = new List<SharedBeacon>();
		}

		public event EventHandler ListChanged;

		public List<SharedBeacon> Data { get; set; }

		public void Init()
		{
			var beaconService = DependencyService.Get<IAltBeaconService>();
			beaconService.ListChanged += (sender, e) => 
			{
				Data = e.Data;
				OnListChanged();
			};
			beaconService.DataClearing += (sender, e) => 
			{
				Data.Clear();
				OnListChanged();
			};

			beaconService.InitializeService();
		}

		private void OnListChanged()
		{
			var handler = ListChanged;
			if(handler != null)
			{
				handler(this, EventArgs.Empty);
			}
=======
		public ICommand AddNewPromptCommand { get; private set; }

		public PromptingHomeViewModel(IMyNavigationService navigationService)
		{
			Data = new List<SharedBeacon>();

			AddNewPromptCommand = new Command(() => {
				//Do something e.g:
				//navigationService.GoBack();
				navigationService.NavigateTo(ViewModelLocator.AddActivityPageKey);
			});
		}



		public event EventHandler ListChanged;

		public List<SharedBeacon> Data { get; set; }

		public void Init()
		{
			var beaconService = DependencyService.Get<IAltBeaconService>();

			// INVOCATION EXCEPTION
			beaconService.ListChanged += (sender, e) => 
			{
				Data = e.Data;
				OnListChanged();
			};
			beaconService.DataClearing += (sender, e) => 
			{
				Data.Clear();
				OnListChanged();
			};

			beaconService.InitializeService();
>>>>>>> jonathan-30-10
		}

		private void OnListChanged()
		{
			var handler = ListChanged;
			if(handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}
	}
}
