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
        public enum MenuItems { Home, Devices, History, Settings, Help }
        public MenuPage ()
		{
            Title = "Menu";
            InitializeComponent();

            MenuList.ItemsSource = Enum.GetValues(typeof(MenuItems)).Cast<MenuItems>();
        }
        private void MenuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            MenuItems item = (MenuItems)e.SelectedItem;

            var oldPage = App.NavigationPage.Navigation.NavigationStack.First();
            var newPage = new object();

            switch (item)
            {
                case MenuItems.Home:
                    newPage = new HomePage();
                    break;
                case MenuItems.Devices:
                    newPage = new MainPage();
                    break;
                case MenuItems.History:
                    newPage = new HistoryPage();
                    break;
                case MenuItems.Settings:
                    newPage = new SettingsPage();
                    break;
                case MenuItems.Help:
                    newPage = new HelpPage();
                    break;
                default:
                    break;
            }

            App.NavigationPage.Navigation.InsertPageBefore((Page)newPage, oldPage);
            App.NavigationPage.PopToRootAsync(false);

            MenuList.SelectedItem = null;
        }
    }
}