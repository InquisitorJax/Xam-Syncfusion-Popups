using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace GettingStartedPicker.View
{
	public class SelectedTimeToDateTimeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// convert DateTime to selectedTime[]
			string format = "00";
			string timeFormat = "AM";
			if (value != null && value is DateTime dateValue)
			{

				string hour = dateValue.TimeOfDay.Hours.ToString(format);
				string minute = dateValue.TimeOfDay.Minutes.ToString(format);

				timeFormat = dateValue.ToString("tt", CultureInfo.InvariantCulture).ToUpperInvariant();
				if (timeFormat == "PM" && dateValue.TimeOfDay.Hours > 12)
				{
					hour = (dateValue.TimeOfDay.Hours - 12).ToString(format);
				}

				if (timeFormat == "AM" && dateValue.TimeOfDay.Hours == 0)
				{
					hour = "12";
				}

				var selectedTime = new[]
				{
					hour,
					minute,
					timeFormat
				};
				return selectedTime;
			}
			string nullFormat = SimpleTimePicker.NullFormat;
			return new object[] { nullFormat, nullFormat, "AM" };
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// convert selectedTime[] to dateTime

			var selectedDate = App.SelectedDate;
			DateTime retDate = selectedDate.Date;

			if (value != null && value is IEnumerable enumerable)
			{
				string[] selectedTime = enumerable.Cast<object>().Select(x => x.ToString()).ToArray();

				if (selectedTime.Any(x => x == "--"))
				{
					return null;
				}

				int hours = int.Parse(selectedTime[0]);
				int minutes = int.Parse(selectedTime[1]);
				string format = selectedTime[2];
				if (format == "PM" && hours < 12)
				{
					hours += 12;
				}

				if (hours == 12 && format == "AM")
				{
					hours = 0;
				}

				retDate = selectedDate.Date.Add(TimeSpan.FromHours(hours).Add(TimeSpan.FromMinutes(minutes)));
				if (parameter != null && format == "AM" && hours == 0 && minutes == 0)
				{
					//for "to" time, interpret 12 AM as midnight (12 AM of next day)
					retDate = selectedDate.Date.Add(TimeSpan.FromDays(1));
				}
			}

			return retDate;
		}
	}
}
