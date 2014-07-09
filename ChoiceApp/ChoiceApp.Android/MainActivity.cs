using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ChoiceApp.Shared.Pages;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

namespace ChoiceApp.Droid
{
    [Activity(Label = "ChoiceApp", MainLauncher = true)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(BuildView());
        }
        static Page BuildView()
        {
			return App.GetMainPage();
        }
    }
}

