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
        }
    }
}