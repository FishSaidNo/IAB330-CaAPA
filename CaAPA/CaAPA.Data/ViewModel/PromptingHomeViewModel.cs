using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace CaAPA.Data
{
	public class PromptingHomeViewModel : ViewModelBase
	{
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
