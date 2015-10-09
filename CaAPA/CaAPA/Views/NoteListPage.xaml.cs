using System;
using System.Collections.Generic;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;
using CaAPA.Data;

namespace CaAPA
{
	public partial class NoteListPage : BaseView
	{
		public NoteListPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.NoteList;


		}

		protected void ButtonClicked(object sender, EventArgs e)
		{
			//Navigation.PushAsync (new NoteDetailsPage ());
			//This never seems to be used
		}

		protected override void OnAppearing ()
		{
			//base.OnAppearing ();
			//var vm = ServiceLocator.Current.GetInstance<RemindersPage> ();
			//vm.OnAppearing ();
		}

	}
}

