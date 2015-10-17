//using System;
//using GalaSoft.MvvmLight;
//using System.Windows.Input;
//using Xamarin.Forms;
//using CaAPA.Data.ViewModel;
//using Microsoft.Practices.ServiceLocation;

using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;

namespace CaAPA.Data
{
	public class PromptingHomeViewModel
	{
//		public ICommand DemoButtonCommand { get; private set; }
//
//		public PromptingHomeViewModel(IMyNavigationService navigationService)
//		{
//
//			DemoButtonCommand = new Command(() => {
//				//Do something e.g:
//				//navigationService.GoBack();
//			});
//
//		}

		public PromptingHomeViewModel(IMyNavigationService navigationService)
		{
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
		}

	}
}
