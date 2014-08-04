using ChoiceApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoiceApp.Shared.Pages
{
    public class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            Label header = new Label
            {
                Text = "MasterDetailPage",
                Font = Font.BoldSystemFontOfSize(30),
                HorizontalOptions = LayoutOptions.Center
            };

            
           

        }

        
    }
}
