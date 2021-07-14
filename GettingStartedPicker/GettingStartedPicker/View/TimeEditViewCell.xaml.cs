using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GettingStartedPicker.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimeEditViewCell : ViewCell
	{
		public TimeEditViewCell()
		{
			InitializeComponent();
		}

		private void From_Tapped(object sender, EventArgs e)
		{
			_fromTimePicker.IsOpen = !_fromTimePicker.IsOpen;
		}

		private void ToTime_Tapped(object sender, EventArgs e)
		{
			_toTimePicker.IsOpen = !_toTimePicker.IsOpen;
		}

	}
}