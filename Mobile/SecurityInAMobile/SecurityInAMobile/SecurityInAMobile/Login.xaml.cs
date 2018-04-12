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

                Application.Current.MainPage = new HomePage();
            }
            else
            {
                DisplayAlert("Warning", "Unknown Box Code", "Ok");
            }
        }
    }
}