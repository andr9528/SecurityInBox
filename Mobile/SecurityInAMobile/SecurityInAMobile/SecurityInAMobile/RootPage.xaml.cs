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
        
        public RootPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;

            App.NavigationPage.PropertyChanged += OnNavChanged;
        }

        private void OnNavChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsPresented = false;
        }
    }
}