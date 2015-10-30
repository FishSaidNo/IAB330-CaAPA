using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;
using GalaSoft.MvvmLight.Views;
using System.Diagnostics;
using Microsoft.Practices.ServiceLocation;

namespace CaAPA
{
	public partial class PromptingHomePage : BaseView
	{
		ListView _list;
//		PromptingHomeViewModel _viewModel;

		public PromptingHomePage()
		{
			BindingContext = App.Locator.PromptingHome;
			InitializeComponent();
			base.Init();
			Title = "Prompting";
			BackgroundColor = Color.FromRgb(255, 255, 255);
//			Content = BuildContent ();
		}

		private View BuildContent() {
			_list = new ListView {
				VerticalOptions = LayoutOptions.FillAndExpand,
//				ItemTemplate = new DataTemplate(typeof(ListItemView)),
				RowHeight = 90,
			};

			_list.ItemsSource = new string[] {
				"Prepare Dinner"
			};

//			_list.SetBinding(ListView.ItemsSourceProperty, "Data");
			_list.ItemSelected += OnSelection;
			_list.ItemTapped += OnTap;

			return _list;
		}

		protected override void OnAppearing()
		{
			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
			var vm = ServiceLocator.Current.GetInstance<PromptingHomeViewModel> ();
//			vm.Init ();
			vm.ListChanged += (sender, e) => {
				_list.ItemsSource = vm.Data;
			};

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
	}
}
