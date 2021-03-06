﻿using System;
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
		public PromptingHomePage()
		{
			BindingContext = App.Locator.PromptingHome;
			InitializeComponent();
			base.Init();
			Title = "Prompting";
			BackgroundColor = Color.FromRgb(255, 255, 255);

			BeaconListView.VerticalOptions = LayoutOptions.FillAndExpand;
			BeaconListView.ItemTemplate = new DataTemplate (typeof(ListItemView));
			BeaconListView.RowHeight = 90;

//			BeaconListView.SetBinding (ListView.ItemsSourceProperty, Data);
//			BeaconListView.ItemSelected += OnSelection;
//			BeaconListView.ItemTapped += OnTap;

		}

		protected override void OnAppearing()
		{
			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
			base.OnAppearing ();
			var vm = ServiceLocator.Current.GetInstance<PromptingHomeViewModel> ();
			vm.Init ();
			vm.ListChanged += (sender, e) => {
				BeaconListView.ItemsSource = vm.Data;
			};

		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args) {
			var item = args.Item as SharedBeacon;
			if (item == null) {
				return;
			}
			Navigation.PushAsync (new StepPage());
			BeaconListView.SelectedItem = null;

		}
	}
}
