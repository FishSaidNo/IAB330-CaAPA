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
<<<<<<< HEAD
		private IMyNavigationService navigationService;
=======
		public ICommand AddNewReminderCommand { get; private set; }
>>>>>>> jonathan-30-10

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

<<<<<<< HEAD
			NewReminderCommand = new Command (() => this.navigationService.NavigateTo (ViewModelLocator.ReminderEntryPageKey));
=======
			AddNewReminderCommand = new Command(() => {
				//Do something e.g:
				//navigationService.GoBack();
				navigationService.NavigateTo(ViewModelLocator.AddReminderPageKey);
			});

>>>>>>> jonathan-30-10
		}

		public void OnAppearing(){
			RaisePropertyChanged (() => ReminderList);
		}
	}
}
