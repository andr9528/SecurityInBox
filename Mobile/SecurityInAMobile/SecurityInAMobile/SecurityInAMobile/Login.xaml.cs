using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecurityInAMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        private void LoginButtonClick(object sender, EventArgs e)
        {
            if (BoxCodeEntry.Text == "1234")
            {
                XmlWriter writer = XmlWriter.Create(Repo.FilePath);
                writer.WriteStartDocument();
                writer.WriteStartElement("Login");
                writer.WriteString("1234");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                MenuPage menuPage = new MenuPage();
                App.NavigationPage = new NavigationPage(new HomePage());
                RootPage rootPage = new RootPage
                {
                    Master = menuPage,
                    Detail = App.NavigationPage
                };
                Application.Current.MainPage = rootPage;
            }
            else
            {
                DisplayAlert("Warning", "Unknown Box Code", "Ok");
            }
        }
    }
}