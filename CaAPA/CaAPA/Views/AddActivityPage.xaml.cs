﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;
using Microsoft.Practices.ServiceLocation;

namespace CaAPA
{
	public partial class AddActivityPage : BaseView
	{
		private const string NumberOfActivitiesKey = "NumberOfActivities";
		private const string BaseActivtiesKey = "BaseActivtiesKey";

		private Activities activity;
		private int currentStep = 1;
		private const string ImageUriKey = "ImageUri";
		

		public AddActivityPage()
		{
			BindingContext = App.Locator.AddActivity;
			InitializeComponent();
			base.Init();
			addStep.IsEnabled = false;
			Title = "Add Activity";
			BackgroundColor = Color.FromRgb(255, 255, 255);

			activity = new Activities ("default");

			if (!Application.Current.Properties.ContainsKey (NumberOfActivitiesKey)) {
				Application.Current.Properties.Add (NumberOfActivitiesKey, 0);
			}


		}

		protected override void OnAppearing()
		{
			var noIcon = "transaprent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
		}

		private void OnNameChanged(object sender, EventArgs e) {
			activity.ActivityName = activityName.Text;
		}

		private void OnLocationChanged(object sender, EventArgs e) {
			activity.ActivityLocation = activityLocation.Text;
		}

		private void OnAddStep(object sender, EventArgs e) {
			if(Application.Current.Properties.ContainsKey(ImageUriKey)){
				activity.AddStep (instructions.Text, (System.Uri)Application.Current.Properties[ImageUriKey]);
			}
			activity.AddStep (instructions.Text);
			currentStep++;
			Steps.Text = "Current Step: " + currentStep;
			instructions.Text = "";
		}

		private void OnEditorChanged(object sender, EventArgs e) {
			if (instructions.Text == "") {
				addStep.IsEnabled = false;
			}
			else {
				addStep.IsEnabled = true;
			}
		}

		private void OnSaveAndQuit(object sender, EventArgs e) {
			if(!Application.Current.Properties.ContainsKey(BaseActivtiesKey + Application.Current.Properties[NumberOfActivitiesKey]) ){
				Application.Current.Properties.Add (BaseActivtiesKey, activity);
//				Navigation.PushAsync (new ActivityHomePage());
			}


		}


//		private void OnSelectImage() {
//			Navigation.PushModalAsync (new ImagePickerPage());
//		}
	}


}

