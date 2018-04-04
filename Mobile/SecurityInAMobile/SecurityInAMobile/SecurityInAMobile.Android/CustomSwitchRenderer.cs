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
using SecurityInAMobile.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Android.Widget.Switch), typeof(CustomSwitchRenderer))]
namespace SecurityInAMobile.Droid
{
    public class CustomSwitchRenderer : SwitchRenderer
    {

    }
}