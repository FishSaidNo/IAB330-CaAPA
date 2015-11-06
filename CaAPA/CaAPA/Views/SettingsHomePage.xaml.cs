using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
	public partial class SettingsHomePage : BaseView
	{
		private const string TextToSpeechSpeedKey = "TextToSpeechSpeed";
		private const string TextToSpeechEnableKey = "TextToSpeechEnable";
		private const string CloudSyncEnableKey = "CloudSyncEnable";
		private const string BackgroundColourKey = "BackgroundColour";

		//to prevent it from changing during setting sliders
		private bool lockbgcol = true;
		
		public SettingsHomePage()
		{
			BindingContext = App.Locator.SettingsHome;
			InitializeComponent();
			base.Init();
			Title = "Settings";
			BackgroundColor = Color.FromRgb(255, 255, 255);
			ttsslider.Value = (double)(float)Application.Current.Properties [TextToSpeechSpeedKey];
			ttsSwitch.IsToggled = (bool)Application.Current.Properties [TextToSpeechEnableKey];
			cloudSwitch.IsToggled = (bool)Application.Current.Properties [CloudSyncEnableKey];
			
			Red.Value = ColourPreview.BackgroundColor.R * 255;
			Green.Value = ColourPreview.BackgroundColor.G * 255;
			Blue.Value = ColourPreview.BackgroundColor.B * 255;
			//unlock the bg colour sliders

			lockbgcol = false;
		}

		
		private void TTSEnableChanged(object sender, EventArgs e){
			if (Application.Current.Properties.ContainsKey (TextToSpeechEnableKey)) {
				Application.Current.Properties [TextToSpeechEnableKey] = ttsSwitch.IsToggled;
			}
		}

		private void OnValueSlide(object sender, EventArgs e){
			if (Application.Current.Properties.ContainsKey (TextToSpeechSpeedKey) && !lockbgcol) {
				Application.Current.Properties [TextToSpeechSpeedKey] = (float)ttsslider.Value;
			}
		}

		private void CloudSyncChanged(object sender, EventArgs e){
			if(Application.Current.Properties.ContainsKey(CloudSyncEnableKey)){
				Application.Current.Properties [CloudSyncEnableKey] = cloudSwitch.IsToggled;
			}
		}

		private void ColourChanged(object sender, EventArgs e){
			if (!lockbgcol) {
				if (Application.Current.Properties.ContainsKey (BackgroundColourKey)) {
					Color temp;
					temp = Color.FromRgb ((int)Red.Value, (int)Green.Value, (int)Blue.Value);
					//BackgroundColor = temp;
					ColourPreview.BackgroundColor = temp;
					Application.Current.Properties [BackgroundColourKey] = temp;
				}
				GC.Collect ();
			}
		}

		private void TTSDemo(object sender, EventArgs e) {
			if ((bool)Application.Current.Properties[TextToSpeechEnableKey]) {
				var speak = DependencyService.Get<ITextToSpeech> ();
				speak.speak ("The Quick Brown Fox Jumps Over The Lazy Dog", (float)Application.Current.Properties [TextToSpeechSpeedKey]);
			}
		}
		
		
		protected override void OnAppearing()
		{
			//Add this to all pages to avoid annoying icon next to the back button
			var noIcon = "transparent1x1.png";
			NavigationPage.SetTitleIcon(this, noIcon);
		}

	}
}
