using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecurityInAMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            NotificationListView.ItemsSource = notifications;
            PopulateList();
            PutListIntoListView();
        }

        List<Notification> notifications = new List<Notification>();

        public void PopulateList()
        {
            notifications.Add(new Notification { Name = "Bob", Data = "He's is mad, bro", Seen = true });
            notifications.Add(new Notification { Name = "Joe & Hugo", Data = "They're are mad, bro", Seen = false });

            NotificationListView.BindingContext = notifications;

            int i = 0;
            while (i < 30)
            {
                notifications.Add(new Notification { Name = "Hans", Data = "No longer mad, bro", Seen = true });
                notifications.Add(new Notification { Name = "Franz", Data = "We call him 'no mad'", Seen = false });
                i++;
            }
        }

        public void PutListIntoListView()
        {
            //notifications.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            //notifications.Sort();
            ListView NotificationListView = this.FindByName<ListView>("NotificationListView");
            NotificationListView.ItemsSource = notifications;
        }
    }
}