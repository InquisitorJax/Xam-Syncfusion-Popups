using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GettingStartedPicker.View
{
    public partial class GettingStarted : ContentPage
    {
        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PickerGettingStarted());
        }

        public GettingStarted()
        {
            InitializeComponent();
        }

		private void Button_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new ListViewPickerPage());
		}
	}
}
