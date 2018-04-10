using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecurityInAMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();

            
            
		}
        private void DisconectButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SettingsPage(); // Change SettingsPage to Login
        }
    }
}