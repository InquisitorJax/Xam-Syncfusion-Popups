using Syncfusion.SfPicker.XForms;
using System;
using System.Collections.ObjectModel;

namespace GettingStartedPicker
{
	public class DurationPicker : SfPicker
	{
		public DurationPicker()
		{
			Time = new ObservableCollection<object>();

			Hour = new ObservableCollection<object>();

			Minute = new ObservableCollection<object>();

			PopulateTimeCollection();

			this.ItemsSource = Time;

			InitializeHeaders();

			ShowHeader = false;
			ShowFooter = false;
		}

		public ObservableCollection<object> Minute { get; }

		public ObservableCollection<object> Hour { get; }
		public ObservableCollection<object> Time { get; set; }

		public ObservableCollection<string> Headers { get; set; }

		protected virtual void InitializeHeaders()
		{
			Headers = new ObservableCollection<string>();

			Headers.Add("Hour");
			Headers.Add("Minute");

			// Column header text collection
			this.ColumnHeaderText = Headers;
		}

		protected virtual void InitializeTime()
		{
			Time = new ObservableCollection<object> { Hour, Minute };
		}

		private void PopulateTimeCollection()
		{
			string format = "00";
			for (int i = 0; i <= 24; i++)
			{
				Hour.Add(i.ToString(format));
			}

			Minute.Add("00");
			Minute.Add("15");
			Minute.Add("30");
			Minute.Add("45");

			InitializeTime();
		}
	}

	//public class DurationPicker : SfPicker
	//   {
	//       private ObservableCollection<object> Time { get; set; }
	//       private ObservableCollection<object> Hour { get; set; }
	//       private ObservableCollection<object> Minute { get; set; }

	//       public DurationPicker()
	//       {
	//           Time = new ObservableCollection<object>();
	//           Hour = new ObservableCollection<object>();
	//           Minute = new ObservableCollection<object>();
	//           ShowColumnHeader = false;
	//		ShowFooter = false;			
	//           PopulateDateCollection();
	//           this.ItemsSource = Time;

	//           SetSelectedTime(new TimeSpan(10, 30, 0));
	//       }

	//       private void SetSelectedTime(TimeSpan time)
	//       {
	//           var h = Hour.IndexOf(time.Hours.ToString());
	//           var m = Minute.IndexOf($"{ time.Minutes:00}");

	//           var selectedIndex = new ObservableCollection<object>();
	//           selectedIndex.Add(h);
	//           selectedIndex.Add(m);


	//           this.SelectedIndex = selectedIndex;
	//       }

	//       private void PopulateDateCollection()
	//       {
	//           for (int i = 1; i <= 24; i++)
	//           {
	//               Hour.Add(i.ToString());
	//           }

	//           for (int j = 0; j < 60; j++)
	//           {
	//               if (j < 10)
	//               {
	//                   Minute.Add("0" + j);
	//               }
	//               else
	//                   Minute.Add(j.ToString());
	//           }



	//           //Populate Time
	//           Time.Add(Hour);
	//           Time.Add(Minute);

	//       }
	//   }

}


