using ChoiceApp.Shared.Models.ViewModels;
using ChoiceApp.Shared.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChoiceApp.Shared.Pages
{
    public class LoginPage : ContentPage
    {
        public ExternalLoginViewModel ExternalLoginProvider
        {
            get;
            set;
        }

        public AuthenticationServices Services
        {
            get;
            set;
        }
        public LoginPage(string url)
        {
            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = url,
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            this.Content = new StackLayout
            {
                Children =
                {                    
                    webView
                }
            };

             
        }
        //private bool IsLocalUser
        //{
        //    get
        //    {
        //        NSHttpCookieStorage cookieJar = NSHttpCookieStorage.SharedStorage;
        //        return cookieJar.Cookies.Any(cookie => cookie.Name == ".AspNet.Cookies");

        //    }
        //}
        private async Task TestAuthorization()
        {
            string uri = String.Format("{0}/api/Values/1", Services.BaseUri);

            HttpWebRequest request = new HttpWebRequest(new Uri(uri));

            request.Headers.Add("Authorization", String.Format("Bearer {0}", Services.AccessToken));
            request.Method = "GET";

            try
            {
                WebResponse response = await request.GetResponseAsync();
                HttpWebResponse httpResponse = (HttpWebResponse)response;
                string result;

                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    result = new StreamReader(responseStream).ReadToEnd();
                    Console.WriteLine(result);
                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
