using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace CaAPA.Data
{
	public class ImagePickerViewModel : ViewModelBase
	{
		//  public ICommand DemoButtonCommand { get; private set; }
		//  public ICommand SaveAndQuit { get; private set; }
		  public ICommand OnSelectImage { get; private set; }

		  public ICommand OpenImageSelector { get; private set; }

		public ImagePickerViewModel(IMyNavigationService navigationService)
		{

			OnSelectImage = new Command(() => {
                //create new model for adding a step
                //Do something e.g:
                navigationService.GoBack();
//                 navigationService.NavigateTo(ViewModelLocator.SamplePagePageKey);
            });
//            SaveAndQuit = new Command(() =>
//            {
//                //actually implement saving somewhere here
//                navigationService.GoBack();
//            });
//            OpenImageSelector = new Command(() =>
//            {
//                //once i get the image selecor in it'll go here
//                //navigationService.NavigateTo();
//            });

		}



	}
}