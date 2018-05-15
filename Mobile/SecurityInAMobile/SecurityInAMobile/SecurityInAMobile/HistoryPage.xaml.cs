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
<<<<<<< HEAD
			InitializeComponent();
            NotificationListView.ItemsSource = notifications;
            PopulateList();
            PutListIntoListView();
		}

        List<Notification> notifications = new List<Notification>();

        public void PopulateList()
        {
            notifications.Add(new Notification { Name = "Bob", Data = "He's is mad, bro", Seen = true});
            notifications.Add(new Notification { Name = "Joe & Hugo", Data = "They're are mad, bro", Seen = false});

            NotificationListView.BindingContext = notifications;
            
            int i = 0;
            while (i < 30)
            {
                notifications.Add(new Notification { Name = "Hans", Data = "No longer mad, bro", Seen = true});
                notifications.Add(new Notification { Name = "Franz", Data = "We call him 'no mad'", Seen = false});
                i++;
            }
        }

        public void PutListIntoListView()
        {
            //notifications.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            //notifications.Sort();
            ListView NotificationListView = this.FindByName<ListView>("NotificationListView");
            NotificationListView.ItemsSource = notifications;
=======
			InitializeComponent ();
            PopulateNewList();
            //PutListsIntoListviews();
        }

        public List<string> newNotificationList = new List<string>();
        public List<string> oldNotificationList = new List<string>();

        public void PopulateNewList()
                {


                    int i = 0;
                    while (i < 30)
                    {
                        oldNotificationList.Add("Pancake");

                        newNotificationList.Add("Pancake");
                        i++;
                    }
            newNotificationList.Add("hello");
            newNotificationList.Add("cookie");
            newNotificationList.Add("completely healthy and alive pony");
            oldNotificationList.Add("Bacon");
        }

        //        public void PutListsIntoListviews()
        //        {
        //            ListView NewNotificationListView = this.FindByName<ListView>("NewNotificationListView");
        //            NewNotificationListView.ItemsSource = newNotificationList;
        //            ListView OldNotificationListView = this.FindByName<ListView>("OldNotificationListView");
        //            OldNotificationListView.ItemsSource = oldNotificationList;

        //        }

        public async Task<List<string>> GetItemsAsync(int pageIndex, int pageSize)
        {
            await Task.Delay(2000);

            return newNotificationList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
>>>>>>> d3ce8b765bc53d5a5ad926277860155f741966c7
        }
    }
}