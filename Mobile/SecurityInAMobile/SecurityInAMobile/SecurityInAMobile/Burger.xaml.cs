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
    public partial class Burger : MasterDetailPage
    {
        public Burger()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as BurgerMenuItem;
            if (item == null)
                return;
            switch (item.Title)
            {
                case "Home":
                    {
                        Detail = new HomePage();
                        break;
                    }
                case "Settings":
                    {
                        Detail = new SettingsPage();
                        break;
                    }
                case "Main":
                    {
                        Detail = new MainPage();
                        break;
                    }
               
                default:
                    {
                       break;
                    }
            }
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            

            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}