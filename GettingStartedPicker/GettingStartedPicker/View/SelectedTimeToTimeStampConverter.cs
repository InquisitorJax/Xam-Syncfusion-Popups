using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace GettingStartedPicker.View
{
	public class SelectedTimeToTimeStampConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// convert TimeStamp to selectedTime[]

			string format = "00";
			if (value != null && value is TimeSpan timsSpanValue)
			{
				string hour = timsSpanValue.Hours.ToString(format);
				string minute = timsSpanValue.Minutes.ToString(format);

				var selectedTime = new[]
				{
					hour,
					minute
				};
				return selectedTime;
			}
			return new object[] { format, format };
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// convert selectedTime[] to TimeStamp

			TimeSpan retTime = new TimeSpan(0);

			if (value != null && value is IEnumerable enumerable)
			{
				string[] selectedTime = enumerable.Cast<object>().Select(x => x.ToString()).ToArray();
				int hours = int.Parse(selectedTime[0]);
				int minutes = int.Parse(selectedTime[1]);
				retTime = TimeSpan.FromHours(hours).Add(TimeSpan.FromMinutes(minutes));
			}

			return retTime;

		}
	}
}
