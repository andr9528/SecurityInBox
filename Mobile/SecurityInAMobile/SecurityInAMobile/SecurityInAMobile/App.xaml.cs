using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SecurityInAMobile;
using Xamarin.Forms;

namespace SecurityInAMobile
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			
		}

		protected override void OnStart ()
		{
            MainPage = new Login();
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
