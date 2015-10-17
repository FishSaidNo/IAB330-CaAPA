using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using CaAPA.Data;

namespace CaAPA
{
	public class PromptingHomePage : ContentPage
	{
		ListView _list;
		BeaconViewModel _viewModel;

		public PromptingHomePage()
		{
			BackgroundColor = Color.White;
			Title = "Prompts";

			_viewModel = new BeaconViewModel();
			_viewModel.ListChanged += (sender, e) => 
			{
				_list.ItemsSource = _viewModel.Data;
			};

			BindingContext = _viewModel;
			Content = BuildContent();
		}

		private View BuildContent()
		{
			_list = new ListView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = new DataTemplate(typeof(ListItemView)),
				RowHeight = 90,
			};

			_list.SetBinding(ListView.ItemsSourceProperty, "Data");

			_list.IsPullToRefreshEnabled = true;
//			_list.Refreshing += OnRefresh;
			_list.ItemSelected += OnSelection;
			_list.ItemTapped += OnTap;

			return _list;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.Init();
		}

		void OnTap (object sender, ItemTappedEventArgs e)
		{
			DisplayAlert ("Item Tapped", e.Item.ToString (), "Ok");
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			DisplayAlert ("Item Selected", e.SelectedItem.ToString (), "Ok");
			//comment out if you want to keep selections
			ListView lst = (ListView)sender;
			lst.SelectedItem = null;
		}

		void OnRefresh (object sender, EventArgs e)
		{
			var list = (ListView)sender;
			//put your refreshing logic here
//			var itemList = items.Reverse().ToList();
			var itemList = _viewModel.Data;
			_viewModel.Data.Clear ();
			foreach (var s in itemList) {
//				_viewModel.Add (s);
			}
			//make sure to end the refresh state
			list.IsRefreshing = false;
		}
	}
}

