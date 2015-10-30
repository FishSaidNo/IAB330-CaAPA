using System;
using Xamarin.Forms;
<<<<<<< HEAD
=======
using System.Diagnostics;
>>>>>>> jonathan-30-10

namespace CaAPA
{
	public class ListItemView : ViewCell
	{
<<<<<<< HEAD
		public ListItemView()
		{
			View = BuildContent();
=======
		public ListItemView ()
		{
			View = BuildContent ();
>>>>>>> jonathan-30-10
		}

		private View BuildContent()
		{
			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.Fill,
				Spacing = 0,
				Padding = 0,
			};

			var beaconId = new Label {
				Text = "E4C8A4FC-F68B-470D-959F-29382AF72CE7",
				TextColor = Color.Black,
				FontFamily = "sans-serif",
				FontSize = 17
			};

			beaconId.SetBinding(Label.TextProperty, "Name");

			var beaconIdLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.End,
				Spacing = 0,
				Padding = new Thickness(0, 10, 10, 5),
				Children = { beaconId }
			};

			viewLayout.Children.Add(beaconIdLayout);

			var beaconDistance = new Label {
				Text = "1.3m",
				TextColor = Color.Black,
				FontFamily = "sans-serif-light",
				FontSize = 36
			};

			beaconDistance.SetBinding(Label.TextProperty, "Distance");

			var beaconDistanceLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.End,
				Spacing = 0,
				Padding = new Thickness(0, 0, 10, 10),
				Children = { beaconDistance }
			};

			viewLayout.Children.Add(beaconDistanceLayout);

			return viewLayout;
		}
	}
}

