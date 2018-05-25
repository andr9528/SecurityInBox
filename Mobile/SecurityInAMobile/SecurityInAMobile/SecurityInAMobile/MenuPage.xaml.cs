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
        public ListView PupMenuList;
        public MenuPage ()
		{
            Title = "Menu";
            InitializeComponent();
            PupMenuList = MenuList;
		}

        private void Settings_Clicked(object sender, EventArgs e)
        {
            var newPage = new SettingsPage();
            var oldPage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(newPage, oldPage);
            App.NavigationPage.PopToRootAsync(false);
        }

        private void Help_Clicked(object sender, EventArgs e)
        {
            var newPage = new HelpPage();
            var oldPage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(newPage, oldPage);
            App.NavigationPage.PopToRootAsync(false);
        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}