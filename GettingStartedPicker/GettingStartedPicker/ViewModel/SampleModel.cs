using System;
using System.Collections.ObjectModel;

namespace GettingStartedPicker.ViewModel
{

	public interface ISelectable
	{
		bool IsSelected { get; set; }
	}

	public class SampleModel : ViewModelBase, ISelectable
    {

		public SampleModel(string name)
		{
			Name = name;
			SetSelectedTime(new TimeSpan(00, 30, 0));
		}

		private void SetSelectedTime(TimeSpan time)
		{
			var h = time.Hours.ToString();
			var m = time.Minutes.ToString();
			var selectedItem = new ObservableCollection<object>();
			selectedItem.Add(h);
			selectedItem.Add(m);
			this.Time = selectedItem;
		}

		private object time;

		public object Time
		{
			get { return time; }
			set
			{
				time = value;
				OnPropertyChanged();
			}
		}


		private string name;

		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged();
			}
		}

		private bool isSelected;

		public bool IsSelected
		{
			get { return isSelected; }
			set
			{
				isSelected = value;
				OnPropertyChanged();
			}
		}


	}
}
