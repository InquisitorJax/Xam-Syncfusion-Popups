using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GettingStartedPicker.View
{
	public class SimpleTimePicker : DurationPicker
	{
		// doc: https://help.syncfusion.com/xamarin/sfpicker/timepicker

		public ObservableCollection<object> Format;

		public const string NullFormat = "--";

		protected override void InitializeTime()
		{
			Format = new ObservableCollection<object>() { "AM", "PM" };

			string format = "00";
			for (int i = 13; i <= 24; i++)
			{
				Hour.Remove(i.ToString(format));
			}
			Hour.Remove(format); //remove zero - as 12 is zero

			//add values for null
			Hour.Insert(0, NullFormat);
			Minute.Insert(0, NullFormat);

			Time = new ObservableCollection<object> { Hour, Minute, Format };
		}

		protected override void InitializeHeaders()
		{
			base.InitializeHeaders();

			Headers.Add("FORMAT");
		}
	}
}
