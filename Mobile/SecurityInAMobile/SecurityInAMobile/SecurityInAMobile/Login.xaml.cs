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
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        private void LoginButtonClick(object sender, EventArgs e)
        {
            if (BoxCodeEntry.Text == "1234")
            {
                Environment.CurrentDirectory = "1234";
                Application.Current.MainPage = new HomePage();
            }
            else
            {
                DisplayAlert("Warning", "Unknown Box Code", "Ok");
            }
        }
    }
}