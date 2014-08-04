using ChoiceApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChoiceApp.Shared.Pages
{
    public class RootPage : ContentPage
    {
        public RootPage()
        {
            Title = "Root Page";
			Content = new Label () {
				Text = "Profile Page",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
           
        }

       

      
    }
}
