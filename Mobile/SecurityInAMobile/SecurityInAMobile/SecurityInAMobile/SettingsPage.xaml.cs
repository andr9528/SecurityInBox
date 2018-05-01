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
	public partial class SettingsPage : ContentPage
	{
        string[] deviceallowedoptions = new string[2] {"Approve All New", "Disapprove All New"};
		public SettingsPage()
		{
			InitializeComponent();

            LoadSettingsFromDB();
		}

        private void LoadSettingsFromDB()
        {
            // Things that is always gonna happen regardless of settings in the Database 
            DeviceAllowedSetting.ItemsSource = deviceallowedoptions;

            // Loading the settings from the Database

            //Psedu setup for testing Purposes
            DeviceAllowedSetting.SelectedIndex = 1;
            DevicesConnectSwitch.IsToggled = true;
            SendNotifySwitch.IsToggled = true;
        }
    }
}