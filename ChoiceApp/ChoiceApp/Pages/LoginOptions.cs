using ChoiceApp.Shared.Models.ViewModels;
using ChoiceApp.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoiceApp.Shared.Pages
{
    public class LoginOptions : ContentPage
    {

        private readonly AuthenticationServices _services = new AuthenticationServices("http://choiceweb.azurewebsites.net/");
        private ExternalLoginViewModel _selectedProvider = null;

        private StackLayout _stackLayout;

        public LoginOptions()
        {
            _stackLayout = new StackLayout();
            NavigationPage.SetHasNavigationBar(this, true);
            this.Content = _stackLayout;
            DisplayProviders();
        }

        public async void DisplayProviders()
        {
            List<ExternalLoginViewModel> externalLoginProviders = new List<ExternalLoginViewModel>(await _services.GetExternalLoginProviders());
			foreach (var item in externalLoginProviders)
	        {
                Button b = new Button(){
                     Text = item.Name,
                      Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
                    
                };
                b.Clicked += async (sender, e) => {
                    await Navigation.PushModalAsync(new LoginPage(item.Url));
                };
               
		        _stackLayout.Children.Add(b);
	        }
            
        }

    }
}
