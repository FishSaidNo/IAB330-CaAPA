using System.Linq;
using Android.Database;
using Android.Content;
using Android.Provider;
using Android.App;
using System;
using System.IO;
using CaAPA.Droid;
using Xamarin.Forms;
using Uri = System.Uri;
using CaAPA.Data;

[assembly: Xamarin.Forms.Dependency (typeof (GalleryAccess_Android))]

namespace CaAPA.Droid
{
	public class GalleryAccess_Android : Java.Lang.Object, IGallery
	{
		public GalleryAccess_Android() { }

		public event EventHandler<ImageSourceEventArgs> ImageSelected;

		public void SetImageFromGallery(Image img){
		}


		public ImageSource GetImageFromUri(System.Uri uri){
			Android.Net.Uri aUri;
			string s;
			s = uri.ToString ();
			s = s.Replace ("image:", "image%3A");
			aUri = Android.Net.Uri.Parse (s);
			ImageSource imageSource = ImageSource.FromStream (() => Forms.Context.ContentResolver.OpenInputStream (aUri));
			ImageSelected.Invoke (this, new ImageSourceEventArgs (uri, imageSource));
			return imageSource;
		}

		private void ResolveImage(Android.Net.Uri uri){
			if (ImageSelected != null) {
				System.UriBuilder URI = new System.UriBuilder();
				URI.Path = uri.EncodedPath;
				URI.Host = uri.Host;
				URI.Scheme = uri.Scheme;
				ImageSource imageSource = ImageSource.FromStream (() => Forms.Context.ContentResolver.OpenInputStream (uri));
			
			}
		}

		public void GetImageFromGallery(){
			MainActivity androidContext = (MainActivity)Forms.Context;
			//Context androidContext = Forms.Context;

			Intent imageIntent = new Intent ();
			imageIntent.SetType ("image/*");
			imageIntent.SetAction (Intent.ActionGetContent);

			androidContext.ConfigureActivityResultCallBack (ImageChooserCallBack);
			androidContext.StartActivityForResult (Intent.CreateChooser (imageIntent, "Select Image"), 0);
		}

		private void ImageChooserCallBack(int requestCode, Result resultCode, Intent data){
			if (resultCode == Result.Ok) {
				if (ImageSelected != null) {
					Android.Net.Uri uri = data.Data;
					System.UriBuilder URI = new System.UriBuilder();
					URI.Path = uri.EncodedPath;
					URI.Host = uri.Host;
					URI.Scheme = uri.Scheme;
					if (ImageSelected != null) {
						ImageSource imageSource = ImageSource.FromStream (() => Forms.Context.ContentResolver.OpenInputStream (uri));
						ImageSelected.Invoke (this, new ImageSourceEventArgs (URI.Uri, imageSource));
					}
				}
			}
		}
	}
}

