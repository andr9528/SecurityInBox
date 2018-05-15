using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecurityInAMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();  
		}
        private void DisconectButton_Clicked(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Repo.FilePath);

                doc.GetElementsByTagName("Login")[0].InnerXml = "";

                doc.Save(Repo.FilePath);               
            }
            catch (Exception ex)
            {
                DisplayAlert("Exception", ex.Message, "Ok");
                throw;
            }

            /*Application.Current.MainPage = new SettingsPage();*/ // Change SettingsPage to Login when Burger has been implemented
            Application.Current.MainPage = new DevicesPage();
        }
    }
}