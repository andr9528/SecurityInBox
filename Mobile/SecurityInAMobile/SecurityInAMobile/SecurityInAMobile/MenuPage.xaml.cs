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
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
            Title = "Menu";
            InitializeComponent ();
		}

        private void Settings_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new SettingsPage());
        }

        private void Help_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new HelpPage());
        }
    }
}