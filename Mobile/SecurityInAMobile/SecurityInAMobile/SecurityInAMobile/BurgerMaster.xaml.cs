using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecurityInAMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BurgerMaster : ContentPage
    {
        public ListView ListView;

        public BurgerMaster()
        {
            InitializeComponent();

            BindingContext = new BurgerMasterViewModel();
            ListView = MenuItemsListView;
        }

        class BurgerMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<BurgerMenuItem> MenuItems { get; set; }
            
            public BurgerMasterViewModel()
            {
                MenuItems = new ObservableCollection<BurgerMenuItem>(new[]
                {
                    new BurgerMenuItem { Id = 0, Title = "Home" },
                    new BurgerMenuItem { Id = 1, Title = "Settings" },
                    new BurgerMenuItem { Id = 2, Title = "Main" },
                    new BurgerMenuItem { Id = 3, Title = "AddMe 4" },
                    new BurgerMenuItem { Id = 4, Title = "AddMe 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}