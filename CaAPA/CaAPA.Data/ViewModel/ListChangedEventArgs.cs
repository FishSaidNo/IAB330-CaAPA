using System;

namespace CaAPA.Data
{
	public class ListChangedEventArgs : EventArgs
	{
		public System.Collections.Generic.List<SharedBeacon> Data { get; protected set; }
		public ListChangedEventArgs(System.Collections.Generic.List<SharedBeacon> data)
		{
			Data = data;
		}
	}
}

