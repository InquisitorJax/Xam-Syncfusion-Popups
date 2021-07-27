using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GettingStartedPicker.OptionsMenu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsDialogContentView : ContentView
	{
		private OptionsDialogViewModel _viewModel => BindingContext as OptionsDialogViewModel;

		private bool _hasAnimated;

		public OptionsDialogContentView()
		{
			InitializeComponent();
		}

		protected override async void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			if (_viewModel != null && _viewModel.ShowToast && height > 0 && !_hasAnimated)
			{
				_hasAnimated = true;
				_optionsFrame.TranslationY = height;
				await _optionsFrame.TranslateTo(0, 0, 150);
			}
			else if (_viewModel != null && !_viewModel.ShowToast && !_hasAnimated)
			{
				_hasAnimated = true;
				_optionsFrame.TranslationY = -height;
				await _optionsFrame.TranslateTo(0, 0, 150);
			}

		}
	}
}