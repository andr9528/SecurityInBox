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
    public partial class DevicesPage : ContentPage
	{
		public DevicesPage ()
		{
			InitializeComponent ();
		}
	    public void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var deviceRepo = e.Item as DeviceRepo;
	        if (BindingContext is DeviceViewModel vm) vm.HideOrShowProduct(deviceRepo);
	    }


	    //private void Button_OnClicked(object sender, EventArgs e)
	    //{
	    //    var btn = sender as Button;
	    //    var product = btn.BindingContext as Product;
	    //    var vm = BindingContext as MainViewModel;

	    //}

	    private void BtnDisapprove_OnClicked(object sender, EventArgs e)
	    {
	        var btn = sender as Button;
	        var deviceRepo = btn.BindingContext as DeviceRepo;
	        var vm = BindingContext as DeviceViewModel;
	        vm.change.Execute(deviceRepo.Id = 0);
	        vm.change.Execute(deviceRepo.Approve = "Disapprove");
	    }

	    private void BtnApprovar_OnClicked(object sender, EventArgs e)
	    {
	        var btn = sender as Button;
	        var deviceRepo = btn.BindingContext as DeviceRepo;
	        var vm = BindingContext as DeviceViewModel;
	        vm.change.Execute(deviceRepo.Id = 1);
	        vm.change.Execute(deviceRepo.Approve = "Approve");
	    }
    }
}