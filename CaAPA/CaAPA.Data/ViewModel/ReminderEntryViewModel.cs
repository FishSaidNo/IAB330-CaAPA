using System;	
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace CaAPA.Data
{
	public class ReminderEntryViewModel : ViewModelBase
	{
		public ICommand SaveReminderCommand { get; private set;}

		private String reminderTitle;

		public String ReminderTitle
		{
			get { return reminderTitle; }
			set { reminderTitle = value; }
		}

		private string reminderDetail;

		public string ReminderDetail
		{
			get { return reminderDetail; }
			set { reminderDetail = value; }
		}

		private bool reminderActionFlag;

		public bool ReminderActionFlag
		{
			get { return reminderActionFlag; }
			set { reminderActionFlag = value; }
		}

		public ReminderEntryViewModel (IMyNavigationService navigationService)
		{
			SaveReminderCommand = new Command (() => {
				var reminderHomeViewModel = ServiceLocator.Current.GetInstance<RemindersHomeViewModel>();

				reminderHomeViewModel.ReminderList.Add(new Note(ReminderTitle, DateTime.Now.ToString(),ReminderActionFlag.ToString(),ReminderDetail));
				navigationService.GoBack();
			});
		}
	}
}

