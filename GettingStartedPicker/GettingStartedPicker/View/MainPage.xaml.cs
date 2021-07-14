using GettingStartedPicker.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
namespace GettingStartedPicker
{
	public partial class MainPage : ContentPage
	{
       
        public MainPage()
		{
			InitializeComponent();
            this.BindingContext = new SampleViewModel();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

        }
       
    }

    public class SampleViewModel : ViewModelBase
    {

        public SampleViewModel()
        {
            ItemCollection.Add(new SampleModel("list1"));
			ItemCollection.Add(new SampleModel("list2"));
			ItemCollection.Add(new SampleModel("list3"));
			ItemCollection.Add(new SampleModel("list4"));
			ItemCollection.Add(new SampleModel("list5"));
			ItemCollection.Add(new SampleModel("list6"));
			ItemCollection.Add(new SampleModel("list7"));
			ItemCollection.Add(new SampleModel("list8"));
            Width = 100;
            SetSelectedTime(new TimeSpan(00, 30, 0));

        }
        private void SetSelectedTime(TimeSpan time)
        {
            var h =time.Hours.ToString();
            var m = time.Minutes.ToString();
            var selectedItem = new ObservableCollection<object>();
            selectedItem.Add(h);
            selectedItem.Add(m);
            this.Time = selectedItem;
        }
        private int pickerwidth;

        public int Width
        {
            get { return pickerwidth; }
            set
            {
                pickerwidth = value;
                OnPropertyChanged();
            }
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

        private List<SampleModel> itemCollection = new List<SampleModel>();

        public List<SampleModel> ItemCollection
        {
            get { return itemCollection; }
            set
            {
                itemCollection = value;
                OnPropertyChanged();
            }
        }


    }
  
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }
    }

}
