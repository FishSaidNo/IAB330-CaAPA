using System;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace CaAPA.Data
{
	public interface IGallery
	{
		void GetImageFromGallery();

		void SetImageFromGallery (Image img);

		ImageSource GetImageFromUri (System.Uri uri);

		event EventHandler<ImageSourceEventArgs> ImageSelected;
	}

	public class ImageSourceEventArgs : EventArgs
	{
		public ImageSourceEventArgs(Uri imageSource, ImageSource source){
			if (imageSource == null)
				throw new ArgumentNullException ("imagesource");
			if (source == null)
				throw new ArgumentNullException ("source");
			ImageSource = imageSource;
			Source = source;
		}
		public Uri ImageSource { get; private set;}
		public ImageSource Source { get; private set;}
	}
}

