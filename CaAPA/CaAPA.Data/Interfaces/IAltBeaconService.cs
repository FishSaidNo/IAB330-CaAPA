using System;

namespace CaAPA.Data
{
	public interface IAltBeaconService
	{
		void InitializeService();
		void StartMonitoring();
		void StartRanging();

		event EventHandler<ListChangedEventArgs> ListChanged;
		event EventHandler DataClearing;
	}	
}

