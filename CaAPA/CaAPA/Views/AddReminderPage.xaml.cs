using System;
using System.Collections.Generic;

using CaAPA.Views;
using Xamarin.Forms;
using CaAPA.Data.ViewModel;
using CaAPA.Data;


namespace CaAPA
{
    public partial class AddReminderPage : BaseView
    {
        public AddReminderPage()
        {
            BindingContext = App.Locator.AddReminder;
            InitializeComponent();
            base.Init();
            Title = "Add Reminder";
            BackgroundColor = Color.White;

        }
    }
}
