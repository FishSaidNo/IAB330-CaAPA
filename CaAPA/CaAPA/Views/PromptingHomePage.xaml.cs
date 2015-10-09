using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

using Xamarin.Forms;

namespace CaAPA
{
	public partial class PromptingHomePage : BaseView
	{
		public PromptingHomePage()
		{
			BindingContext = App.Locator.PromptingHome;
			InitializeComponent();
			base.Init();
			Title = "Prompting";
			//Icon =
		}

		protected override void OnAppearing()
		{

		}
	}
}
