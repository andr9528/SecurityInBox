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

            DeviceAllowedSetting.ItemsSource = deviceallowedoptions;
            DeviceAllowedSetting.SelectedIndex = 0;
		}
	}
}