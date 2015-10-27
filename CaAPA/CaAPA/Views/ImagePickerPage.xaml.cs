using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

using Xamarin.Forms;

namespace CaAPA
{
    public partial class ImagePickerPage : BaseView
    {
        public ImagePickerPage()
        {
            BindingContext = App.Locator.SamplePage;
            InitializeComponent();
            base.Init();
            Title = "Pick a Image";
            BackgroundColor = Color.FromRgb(255, 255, 255);
        }

        protected override void OnAppearing()
        {
            //Add this to all pages to avoid annoying icon next to the back button
            var noIcon = "transparent1x1.png";
            NavigationPage.SetTitleIcon(this, noIcon);
        }
    }
}