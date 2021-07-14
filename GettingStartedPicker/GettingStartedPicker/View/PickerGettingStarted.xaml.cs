using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
namespace GettingStartedPicker.View
{
    public partial class PickerGettingStarted : ContentPage
    {
        public PickerGettingStarted()
        {
            InitializeComponent();
            this.BindingContext = new SampleViewModel();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }


    }
}
