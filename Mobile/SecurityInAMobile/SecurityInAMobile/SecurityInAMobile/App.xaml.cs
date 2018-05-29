using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using SecurityInAMobile;
using Xamarin.Forms;

namespace SecurityInAMobile
{
	public partial class App : Application
	{
        public static NavigationPage NavigationPage { get; set; }
        public App ()
		{
			InitializeComponent();

            Repo.Path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            Repo.FilePath = Path.Combine(Repo.Path, "DataFile.xml");
        }

		protected override void OnStart ()
		{
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Repo.FilePath);

                if (doc.GetElementsByTagName("Login")[0].InnerXml == "1234")
                {
                    MenuPage menuPage = new MenuPage();
                    NavigationPage = new NavigationPage(new HomePage());
                    RootPage RootPage = new RootPage
                    {
                        Master = menuPage,
                        Detail = NavigationPage
                    };
                    MainPage = RootPage;
                }
                else
                {
                    MainPage = new Login();
                }
            }
            catch (Exception e)
            {
                MainPage = new Login();
            }
            
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
