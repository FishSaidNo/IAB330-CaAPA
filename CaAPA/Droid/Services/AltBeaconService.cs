﻿using System;
using AltBeaconOrg.BoundBeacon;
using Android.Widget;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Android.App;
using CaAPA.Droid;
using CaAPA.Data;

[assembly: Xamarin.Forms.Dependency(typeof(AltBeaconService))]

namespace CaAPA.Droid
{
	public class AltBeaconService : Java.Lang.Object, IAltBeaconService
	{
		private readonly MonitorNotifier _monitorNotifier;
		private readonly RangeNotifier _rangeNotifier;
		private BeaconManager _beaconManager;

//		Region _tagRegion;
		Region region1;
		Region region2;
		Region region3;
		Region region4;
		Region _emptyRegion;
		private ListView _list;
		private readonly List<Beacon> _data;

		public AltBeaconService()
		{
			_monitorNotifier = new MonitorNotifier();
			_rangeNotifier = new RangeNotifier();
			_data = new List<Beacon>();
		}

		public event EventHandler<ListChangedEventArgs> ListChanged;
		public event EventHandler DataClearing;

		public BeaconManager BeaconManagerImpl
		{
			get {
				if (_beaconManager == null)
				{
					_beaconManager = InitializeBeaconManager();
				}
				return _beaconManager;
			}
		}

		public void InitializeService()
		{
			_beaconManager = InitializeBeaconManager();
		}

		private BeaconManager InitializeBeaconManager()
		{
			// Enable the BeaconManager 
			BeaconManager bm = BeaconManager.GetInstanceForApplication(Xamarin.Forms.Forms.Context);

			#region Set up Beacon Simulator if testing without a BLE device
			var beaconSimulator = new BeaconSimulator();
			beaconSimulator.CreateBasicSimulatedBeacons();
			BeaconManager.BeaconSimulator = beaconSimulator;
			#endregion

			var iBeaconParser = new BeaconParser();
			//	Estimote > 2013
			iBeaconParser.SetBeaconLayout("m:2-3=0215,i:4-19,i:20-21,i:22-23,p:24-24");
			bm.BeaconParsers.Add(iBeaconParser);

			_monitorNotifier.EnterRegionComplete += EnteredRegion;
			_monitorNotifier.ExitRegionComplete += ExitedRegion;
			_monitorNotifier.DetermineStateForRegionComplete += DeterminedStateForRegionComplete;
			_rangeNotifier.DidRangeBeaconsInRegionComplete += RangingBeaconsInRegion;

			region1 = new AltBeaconOrg.BoundBeacon.Region("myUniqueBeaconId1", Identifier.Parse("DF7E1C79-43E9-44FF-886F-1D1F7DA6997A"), Identifier.Parse("1"), Identifier.Parse("1"));
			region2 = new AltBeaconOrg.BoundBeacon.Region("myUniqueBeaconId2", Identifier.Parse("DF7E1C79-43E9-44FF-886F-1D1F7DA6997A"), Identifier.Parse("1"), Identifier.Parse("2"));
//			region3 = new AltBeaconOrg.BoundBeacon.Region("myUniqueBeaconId3", Identifier.Parse("E2C56DB5-DFFB-48D2-B060-D0F5A71096E0"), null, null);
//			region4 = new AltBeaconOrg.BoundBeacon.Region("myUniqueBeaconId4", Identifier.Parse("5A4BCFCE-174E-4BAC-A814-092E77F6B7E5"), null, null);
			_emptyRegion = new AltBeaconOrg.BoundBeacon.Region("myEmptyBeaconId", null, null, null);

			bm.SetBackgroundMode(false);
			bm.Bind((IBeaconConsumer)Xamarin.Forms.Forms.Context);

			return bm;
		}

		public void StartMonitoring()
		{
			BeaconManagerImpl.SetForegroundBetweenScanPeriod(5000); // 5000 milliseconds

			BeaconManagerImpl.SetMonitorNotifier(_monitorNotifier); 
//			_beaconManager.StartMonitoringBeaconsInRegion(_tagRegion);
			_beaconManager.StartMonitoringBeaconsInRegion(region1);
			_beaconManager.StartMonitoringBeaconsInRegion(region2);
//			_beaconManager.StartMonitoringBeaconsInRegion(region3);
//			_beaconManager.StartMonitoringBeaconsInRegion(region4);
			_beaconManager.StartMonitoringBeaconsInRegion(_emptyRegion);
		}

		public void StartRanging()
		{
			BeaconManagerImpl.SetForegroundBetweenScanPeriod(5000); // 5000 milliseconds

			BeaconManagerImpl.SetRangeNotifier(_rangeNotifier);
//			_beaconManager.StartRangingBeaconsInRegion(_tagRegion);
			_beaconManager.StartRangingBeaconsInRegion(region1);
			_beaconManager.StartRangingBeaconsInRegion(region2);
//			_beaconManager.StartRangingBeaconsInRegion(region3);
//			_beaconManager.StartRangingBeaconsInRegion(region4);
			_beaconManager.StartRangingBeaconsInRegion(_emptyRegion);
		}

		private void DeterminedStateForRegionComplete(object sender, MonitorEventArgs e)
		{
			Console.WriteLine("DeterminedStateForRegionComplete");
		}

		private void ExitedRegion(object sender, MonitorEventArgs e)
		{
			Console.WriteLine("ExitedRegion");
		}

		private void EnteredRegion(object sender, MonitorEventArgs e)
		{
			Console.WriteLine("EnteredRegion");
		}

		async void RangingBeaconsInRegion(object sender, RangeEventArgs e)
		{
			await ClearData();

			var allBeacons = new List<Beacon>();
			if(e.Beacons.Count > 0)
			{
				foreach(var b in e.Beacons)
				{
					allBeacons.Add(b);
				}

				var orderedBeacons = allBeacons.OrderBy(b => b.Distance).ToList();
				await UpdateData(orderedBeacons);
			}
			else
			{
				// unknown
				await ClearData();
			}
		}

		private async Task UpdateData(List<Beacon> beacons)
		{
			await Task.Run(() =>
				{	
					var newBeacons = new List<Beacon>();
					foreach(var beacon in beacons)
					{
						if(_data.All(b => b.Id1.ToString() == beacon.Id1.ToString()))
						{
							newBeacons.Add(beacon);
						}
					}

					((Activity)Xamarin.Forms.Forms.Context).RunOnUiThread(() =>
						{
							foreach(var beacon in newBeacons)
							{
								_data.Add(beacon);
							}

							if (newBeacons.Count > 0)
							{
								_data.Sort((x,y) => x.Distance.CompareTo(y.Distance));
								UpdateList();
							}
						});
				});
		}

		private async Task ClearData()
		{
			((Activity)Xamarin.Forms.Forms.Context).RunOnUiThread(() =>
				{
					_data.Clear();
					OnDataClearing();
				});
		}

		private void OnDataClearing()
		{
			var handler = DataClearing;
			if(handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}

		private void UpdateList()
		{
			((Activity)Xamarin.Forms.Forms.Context).RunOnUiThread(() => 
				{
					OnListChanged();
				});
		}

		private void OnListChanged()
		{
			var handler = ListChanged;
			if(handler != null)
			{
				var data = new List<SharedBeacon>();
				_data.ForEach(b =>
					{
						data.Add(new SharedBeacon { Id = b.Id1.ToString(), Distance = string.Format("{0:N2}m", b.Distance)});
					});
				handler(this, new ListChangedEventArgs(data));
			}
		}
	}
}

