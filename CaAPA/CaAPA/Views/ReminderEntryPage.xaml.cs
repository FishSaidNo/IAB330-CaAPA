using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public partial class ReminderEntryPage : BaseView
	{
		public ReminderEntryPage ()
		{
			BindingContext = App.Locator.ReminderEntry;
			InitializeComponent ();
			base.Init ();
			Title = "New Reminder";
		}
	}
}

