using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public class PromptingHomePage : BaseView
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

			return _list;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.Init();
		}
	}
}

