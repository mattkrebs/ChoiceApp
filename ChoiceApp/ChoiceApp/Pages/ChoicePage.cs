using ChoiceApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoiceApp.Shared.Pages
{
    public class ChoicePage : ContentPage
    {
        public ChoicePage()
        {
            this.SetBinding(ContentPage.TitleProperty, "Name");
            Image image1 = new Image();
            image1.SetBinding(Image.SourceProperty, "Option1.ImageUrl");

            Image image2 = new Image();
            image2.SetBinding(Image.SourceProperty, "Option2.ImageUrl");

            this.Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = 
                        {
                            image1, image2                           
                            
                        }
            };
           
        }
       
    }
}
