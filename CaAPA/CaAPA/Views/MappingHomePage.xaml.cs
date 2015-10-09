using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

using Xamarin.Forms;

namespace CaAPA
{
	public partial class MappingHomePage : BaseView
	{
		public MappingHomePage()
		{
			BindingContext = App.Locator.MappingHome;
			InitializeComponent();
			base.Init();
			Title = "Mapping";
			//Icon =
		}

		protected override void OnAppearing()
		{

		}
	}
}
