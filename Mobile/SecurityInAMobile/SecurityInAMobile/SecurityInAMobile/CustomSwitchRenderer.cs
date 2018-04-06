using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SecurityInAMobile;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Android.Widget.Switch), typeof(CustomSwitchRenderer))]
namespace SecurityInAMobile
{
    public class CustomSwitchRenderer : SwitchRenderer
    {
        public CustomSwitchRenderer(Context context) : base(context)
        {
            
        }
    }
}