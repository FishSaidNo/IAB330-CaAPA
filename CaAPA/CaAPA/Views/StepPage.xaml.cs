using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public partial class StepPage : BaseView
	{
		public string[] steps;
		public int counter = 0;

		public StepPage()
		{
			BindingContext = App.Locator.Step;
			InitializeComponent();
			base.Init();
			Title = "Steps";
			BackgroundColor = Color.White;

			/* IN CASE OF EMERGENCY */
			steps = new string[] {
				"Open Pantry",
				"Get Can of Soup",
				"Put Can of Soup on Table", 
				"Open Top Drawer",
				"Get Can Opener",
				"Open Can Using Can Opener",
				"Open Cupboard",
				"Get Bowl",
				"Pour Contents of Can into Bowl",
				"Put Bowl in Microwave",
				"Set Timer to 4 minutes",
				"Press Start",
				"Enjoy"
			};

		}
		protected override void OnAppearing()
		{
			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
//			activityNameLabel.Text = activity.ActivityName;
//			activityLocationLabel.Text = activity.ActivityLocation;
			instructions.Text = steps [0];
		}
		private void goForwardStep(object sender, EventArgs e)
		{
			//check if this step is last
			//load next step in this same view

			counter += 1;
			if (counter < steps.Length) {
				instructions.Text = steps [counter];
			}
//			activityNameLabel.Text = activity.ActivityName;
			//			instructions.Text =
		}

		private void goBackStep(object sender, EventArgs e)
		{
			//if step is first return us to main view we launched from
			//load previous step in same view
			//activity.decrement step

			counter -= 1;
			instructions.Text = steps [counter];
//			activityNameLabel.Text = activity.ActivityName;
			//			instructions.Text =
		}
	}
}