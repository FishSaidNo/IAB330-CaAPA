using System;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace CaAPA.Data
{
	public interface IGallery
	{
		void GetImageFromGallery();

		void SetImageFromGallery(Image img);

		event EventHandler<ImageSourceEventArgs> ImageSelected;
	}

	public class ImageSourceEventArgs : EventArgs
	{
		public ImageSourceEventArgs(Uri imageSource)
		{
			if (imageSource == null)
				throw new ArgumentNullException("imagesource");
			ImageSource = imageSource;
		}
		public Uri ImageSource { get; private set; }
	}
}
