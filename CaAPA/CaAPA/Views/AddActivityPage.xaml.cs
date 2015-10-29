using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;

namespace CaAPA
{
    public partial class AddActivityPage : BaseView
    {
        public AddActivityPage()
        {
            BindingContext = App.Locator.AddActivity;
            InitializeComponent();
            base.Init();
            Title = "Add Activity";
            BackgroundColor = Color.FromRgb(255, 255, 255);
        }

        protected override void OnAppearing()
        {
            var noIcon = "transaprent1x1.png";
            NavigationPage.SetTitleIcon(this, noIcon);
        }
    }
}
