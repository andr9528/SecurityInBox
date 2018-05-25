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
    public partial class RootPage : MasterDetailPage
    {
        public enum MenuItems { Home, Devices, History, Settings, Help }
        public RootPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;

            MenuPage.PupMenuList.ItemsSource = Enum.GetValues(typeof(MenuItems)).Cast<MenuItems>();
            MenuPage.PupMenuList.ItemSelected += MenuList_ItemSelected;
        }
        private void MenuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MenuItems item = (MenuItems)e.SelectedItem;

            var oldPage = App.NavigationPage.Navigation.NavigationStack.First();


            switch (item)
            {
                case MenuItems.Home:
                    var newPage = new HomePage();
                    App.NavigationPage.Navigation.InsertPageBefore(newPage, oldPage);
                    break;
                default:
                    break;
            }

            App.NavigationPage.PopToRootAsync(false);

            IsPresented = false;
            MenuPage.PupMenuList.SelectedItem = null;
        }
    }
}