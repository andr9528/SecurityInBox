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
		public HistoryPage ()
		{
			InitializeComponent ();
            PopulateNewList();
            PutListsIntoListviews();
		}

        public List<string> NewNotificationList = new List<string>();
        public List<string> OldNotificationList = new List<string>();

        public void PopulateNewList()
        {
            

            int i = 0;
            while (i < 30)
            {
                OldNotificationList.Add("Pancake");

                NewNotificationList.Add("Pancake");
                i++;
            }
NewNotificationList.Add("hello");
            NewNotificationList.Add("cookie");
            NewNotificationList.Add("completely healthy and alive pony");
            OldNotificationList.Add("Bacon");
        }

        public void PutListsIntoListviews()
        {
            ListView NewNotificationListView = this.FindByName<ListView>("NewNotificationListView");
            NewNotificationListView.ItemsSource = NewNotificationList;
            ListView OldNotificationListView = this.FindByName<ListView>("OldNotificationListView");
            OldNotificationListView.ItemsSource = OldNotificationList;

        }
    }
}