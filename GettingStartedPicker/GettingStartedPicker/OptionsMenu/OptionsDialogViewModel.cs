using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows.Input;

namespace GettingStartedPicker.OptionsMenu
{
	public class OptionsDialogViewModel : BindableBase
	{
		public OptionsDialogViewModel(List<OptionMenuItem> options, bool showToast)
		{
			Options = options;
			ShowToast = showToast;
		}

		public bool ShowToast { get; set; }

		public List<OptionMenuItem> Options { get; }

		public ICommand ShowSubscriptionPageCommand { get; }

		private ICommand _optionSelectedCommand;

		public ICommand OptionSelectedCommand
		{
			get { return _optionSelectedCommand; }
			set { SetProperty(ref _optionSelectedCommand, value); }
		}

		private ICommand _closeCommand;

		public ICommand CloseCommand
		{
			get { return _closeCommand; }
			set { SetProperty(ref _closeCommand, value); }
		}
	}
}
