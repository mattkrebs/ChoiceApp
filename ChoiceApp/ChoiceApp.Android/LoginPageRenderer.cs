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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ChoiceApp.Shared.Pages;
using Xamarin.Auth;
using ChoiceApp.Droid;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace ChoiceApp.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        protected override void OnModelChanged(VisualElement oldModel, VisualElement newModel)
        {
            base.OnModelChanged(oldModel, newModel);
            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator (
				clientId: "226855460778202", // your OAuth2 client id
                scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
				authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"),
				redirectUrl: new Uri ("http://www.facebook.com/connect/login_success.html")); // the redirect URL for the service

            auth.Completed += (sender, eventArgs) => {
            if (eventArgs.IsAuthenticated) {
                App.SuccessfulLoginAction.Invoke();
                // Use eventArgs.Account to do wonderful things
                App.SaveToken(eventArgs.Account.Properties["access_token"]);
            } else {
                // The user cancelled
            }
        };

        activity.StartActivity (auth.GetUI(activity));
        
        }
    }
}