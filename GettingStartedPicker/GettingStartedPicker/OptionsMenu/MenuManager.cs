using Prism.Commands;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GettingStartedPicker.OptionsMenu
{
	public static class MenuManager
	{
		public static Task<string> ShowMenuOptionsAsync(List<OptionMenuItem> options, Xamarin.Forms.View relativeView, bool showToastBottom)
		{
			// landscape = show fade-in top right ; portrait = show toast bottom

			bool resultSet = false;
			var tcs = new TaskCompletionSource<string>();

			var popup = new SfPopupLayout()
			{
				RelativePosition = showToastBottom ? RelativePosition.AlignBottom : RelativePosition.AlignTopRight
			};
			popup.PopupView.ShowHeader = false;
			popup.PopupView.ShowFooter = false;
			popup.PopupView.BackgroundColor = Color.Transparent;
			popup.PopupView.PopupStyle.BorderThickness = 0;
			if (!showToastBottom)
			{
				popup.PopupView.AutoSizeMode = AutoSizeMode.Both;
			}

			var viewModel = new OptionsDialogViewModel(options, showToastBottom);
			var optionsView = new OptionsDialogContentView()
			{
				BindingContext = viewModel
			};
			popup.PopupView.ContentTemplate = new DataTemplate(() => optionsView);
			viewModel.OptionSelectedCommand = new DelegateCommand<string>(option =>
			{
				resultSet = true;
				tcs.TrySetResult(option);
				popup.Dismiss();
			});

			viewModel.CloseCommand = new DelegateCommand(() =>
			{
				resultSet = true;
				tcs.TrySetResult(string.Empty);
				popup.Dismiss();
			});

			popup.Closed += (sender, e) =>
			{
				if (!resultSet)
				{
					tcs.TrySetResult(string.Empty);
				}
			};

			if (showToastBottom)
			{
				popup.Show(isFullScreen: true);
			}
			else
			{
				popup.ShowRelativeToView(relativeView, popup.RelativePosition);
			}

			return tcs.Task;
		}
	}

	public class OptionMenuItem
	{
		public OptionMenuItem(string text, string imageSource)
		{
			Text = text;
			ImageSource = imageSource;
		}
		public string ImageSource { get; }

		public string Text { get; }
	}
}
