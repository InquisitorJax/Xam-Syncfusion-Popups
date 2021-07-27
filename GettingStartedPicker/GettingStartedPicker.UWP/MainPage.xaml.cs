namespace GettingStartedPicker.UWP
{
	public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Syncfusion.XForms.UWP.PopupLayout.SfPopupLayoutRenderer.Init();

            LoadApplication(new GettingStartedPicker.App());
        }
    }
}
