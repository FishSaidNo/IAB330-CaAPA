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
using GalaSoft.MvvmLight;

namespace CaAPA.Data
{
	public class PromptingHomeViewModel : ViewModelBase
	{
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
		}

	}
}
