using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public partial class ImagePickerPage : BaseView
	{
		private const string TextToSpeechSpeedKey = "TextToSpeechSpeed";
		private const string TextToSpeechEnableKey = "TextToSpeechEnable";
		private const string CloudSyncEnableKey = "CloudSyncEnable";
		private const string BackgroundColourKey = "BackgroundColour";
		private const string ImageUriKey = "ImageUri";		
		
		private System.Uri uri = null;
		
		public ImagePickerPage()
		{
			BindingContext = App.Locator.ImagePicker;
			InitializeComponent();
			base.Init();
			Title = "Pick a Image";
			BackgroundColor = Color.FromRgb(255, 255, 255);
		}

		protected override void OnAppearing()
		{
			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
		}

		private void OnPick(object sender, EventArgs e) {
			var gallery = Xamarin.Forms.DependencyService.Get<IGallery> ();

			if (gallery != null) {
				gallery.ImageSelected += ((o, ImageSourceEventArgs) => {
					uri = ImageSourceEventArgs.ImageSource;
					img.Source = ImageSourceEventArgs.Source;
					if(Application.Current.Properties.ContainsKey(ImageUriKey)){
						Application.Current.Properties [ImageUriKey] = uri;
					} else {
						Application.Current.Properties.Add(ImageUriKey, uri);
					}
				});
				gallery.GetImageFromGallery ();
			}
		}

	}
}