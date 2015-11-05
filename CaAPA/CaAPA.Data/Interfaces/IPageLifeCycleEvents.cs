using System;

namespace CaAPA.Data
{
	public interface IPageLifeCycleEvents
	{
		void OnAppearing();
		void OnDisappearing();
		void OnLayoutChanged();
	}
}

