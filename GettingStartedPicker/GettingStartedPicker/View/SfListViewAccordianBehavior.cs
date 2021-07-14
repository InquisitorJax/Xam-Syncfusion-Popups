using GettingStartedPicker.ViewModel;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using Xamarin.Forms;

namespace GettingStartedPicker.View
{
	internal class SfListViewAccordionBehavior : Behavior<SfListView>
	{
		//from syncfusion samples https://help.syncfusion.com/xamarin/sflistview/item-size-customization?cs-save-lang=1&cs-lang=xaml Accordian
		private ISelectable _tappedItem;
		private SfListView _listView;

		#region Override Methods

		protected override void OnAttachedTo(SfListView bindable)
		{
			_listView = bindable;
			_listView.ItemTapped += ListView_ItemTapped;
		}

		protected override void OnDetachingFrom(BindableObject bindable)
		{
			_listView.ItemTapped -= ListView_ItemTapped;
		}

		#endregion

		#region Private Methods

		private void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
		{
			if (_tappedItem != null && _tappedItem.IsSelected)
			{
				var previousIndex = _listView.DataSource.DisplayItems.IndexOf(_tappedItem);

				_tappedItem.IsSelected = false;

				if (Device.RuntimePlatform != Device.macOS)
				{
					Device.BeginInvokeOnMainThread(() => { _listView.RefreshListViewItem(previousIndex, previousIndex, false); });
				}
			}

			if (_tappedItem == (e.ItemData as ISelectable))
			{
				if (Device.RuntimePlatform == Device.macOS)
				{
					var previousIndex = _listView.DataSource.DisplayItems.IndexOf(_tappedItem);
					Device.BeginInvokeOnMainThread(() => { _listView.RefreshListViewItem(previousIndex, previousIndex, false); });
				}

				_tappedItem = null;
				return;
			}

			_tappedItem = e.ItemData as ISelectable;
			_tappedItem.IsSelected = true;

			if (Device.RuntimePlatform == Device.macOS)
			{
				var visibleLines = this._listView.GetVisualContainer().ScrollRows.GetVisibleLines();
				var firstIndex = visibleLines[visibleLines.FirstBodyVisibleIndex].LineIndex;
				var lastIndex = visibleLines[visibleLines.LastBodyVisibleIndex].LineIndex;
				Device.BeginInvokeOnMainThread(() => { _listView.RefreshListViewItem(firstIndex, lastIndex, false); });
			}
			else
			{
				var currentIndex = _listView.DataSource.DisplayItems.IndexOf(e.ItemData);
				Device.BeginInvokeOnMainThread(() => { _listView.RefreshListViewItem(currentIndex, currentIndex, false); });
			}
		}

		#endregion
	}
}
