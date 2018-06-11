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
	public partial class HistoryPage : ContentPage
	{
        public HistoryPage()
        {
            InitializeComponent();
            PopulateList();

            PutListIntoListView();


        }

        List<Notification> notifications = new List<Notification>();

        public void PopulateList()
        {
            notifications.Add(new Notification { Name = "Bob", Data = "He's is mad, bro", Seen = true, Date = DateTime.Now });
            notifications.Add(new Notification { Name = "Joe & Hugo", Data = "They're are mad, bro", Seen = false, Date = DateTime.Now });

            Random random = new Random();

            int i = 0;
            while (i < 30)
            {
                notifications.Add(new Notification { Name = "Hans", Data = "No longer mad, bro", Seen = true, Date = DateTime.Now.AddDays(-(random.Next(0, 10000))) });
                notifications.Add(new Notification { Name = "Franz", Data = "We call him 'no mad'", Seen = false, Date = DateTime.Now.AddDays(-(random.Next(0, 10000))) });
                i++;
            }
        }

        public void PutListIntoListView()
        {
            notifications.Sort((y, x) => DateTime.Compare(x.Date, y.Date));
            ListView NotificationListView = this.FindByName<ListView>("NotificationListView");
            NotificationListView.ItemsSource = notifications;
            NotificationListView.BindingContext = notifications;
        }

        public void OnStuffSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*      if (e.SelectedItem == null)
      {
          return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
      }
  */
            notifications.Add(new Notification { Name = "ItemClicked", Data = "You Clicked an item!", Seen = false, Date = DateTime.Now });
            PutListIntoListView();
        }
    }
}