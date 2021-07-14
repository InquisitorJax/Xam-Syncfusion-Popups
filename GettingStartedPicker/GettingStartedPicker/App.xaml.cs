using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingStartedPicker.View;
using Xamarin.Forms;

namespace GettingStartedPicker
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new GettingStarted());
		}

		public static DateTime SelectedDate => DateTime.Now;

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
