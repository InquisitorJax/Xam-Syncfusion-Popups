using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace GettingStartedPicker.ViewModel
{
	public class ListPickerViewModel : BindableBase
	{

		public ListPickerViewModel()
		{
			ItemCollection = new ObservableCollection<ListPickerDurationModel>();
			ItemCollection.Add(new ListPickerDurationModel());
			ItemCollection.Add(new ListPickerDurationModel());
			ItemCollection.Add(new ListPickerDurationModel());
			ItemCollection.Add(new ListPickerDurationModel());
			ItemCollection.Add(new ListPickerDurationModel());
			ItemCollection.Add(new ListPickerDurationModel());
			ItemCollection.Add(new ListPickerDurationModel());
			ItemCollection.Add(new ListPickerDurationModel());
		}

		private ObservableCollection<ListPickerDurationModel> _itemCollection;

		public ObservableCollection<ListPickerDurationModel> ItemCollection
		{
			get { return _itemCollection; }
			set { SetProperty(ref _itemCollection, value); }
		}

	}

	public class ListPickerDurationModel : BindableBase
	{
		private DateTime? _fromTime;

		public DateTime? FromTime
		{
			get { return _fromTime; }
			set { SetProperty(ref _fromTime, value); }
		}

		private DateTime? _toTime;

		public DateTime? ToTime
		{
			get { return _toTime; }
			set { SetProperty(ref _toTime, value); }
		}

	}
}
