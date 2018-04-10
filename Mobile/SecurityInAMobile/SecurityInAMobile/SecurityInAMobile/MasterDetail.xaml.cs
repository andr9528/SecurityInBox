using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecurityInAMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetail : MasterDetailPage
    {

        public MasterDetail ()
		{
			InitializeComponent ();
            tes
        }
        void CreateLabelsForMenu()
        {
            
        }

       

        void Page1Clicked(object sender, System.EventArgs e)
        {
            Detail = new Page1();
            IsPresented = false;
         
        }
         
        void HomeClicked()
        {
            Detail = new MasterDetail();
            IsPresented = false;

        }

    }
}