using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CaAPA.Data.ViewModel
{
	public class RemindersHomeViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public ObservableCollection<Note> ReminderList {
			get {
				var database = new NoteDatabase ();
				var x = database.GetAll ();
				return new ObservableCollection<Note> (x);
			}
		}

		public ICommand NewReminderCommand { get; private set; }
		public RemindersHomeViewModel(IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;

			NewReminderCommand = new Command (() => this.navigationService.NavigateTo (ViewModelLocator.ReminderEntryPageKey));
		}

		public void OnAppearing(){
			RaisePropertyChanged (() => ReminderList);
		}
	}
}
