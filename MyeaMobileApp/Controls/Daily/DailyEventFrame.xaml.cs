using System;
using Microsoft.Maui.Controls;

namespace MyeaMobileApp.Controls.Daily
{
    public partial class DailyEventFrame : ContentView
    {
        public DailyEventFrame()
        {
            InitializeComponent();
        }

        private async void OnFrameTapped(object sender, EventArgs e)
        {
            // Assuming you have a navigation method available
            await Shell.Current.GoToAsync("///AboutUsPage");
        }
    }
}
