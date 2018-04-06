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

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace SecurityInAMobile
{
    public class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {

        }
    }
}