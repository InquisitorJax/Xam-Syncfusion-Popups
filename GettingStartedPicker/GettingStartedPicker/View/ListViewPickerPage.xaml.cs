using GettingStartedPicker.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GettingStartedPicker.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPickerPage : ContentPage
	{
		public ListViewPickerPage()
		{
			this.BindingContext = new ListPickerViewModel();
			InitializeComponent();
		}
	}
}