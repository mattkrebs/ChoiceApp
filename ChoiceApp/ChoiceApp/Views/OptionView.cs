using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoiceApp.Shared.Views
{
    public class OptionView : View
    {
        public OptionView()
        {
            var image = new Image();
            image.SetBinding(Image.SourceProperty, "ImageUrl");
            
            
            
        }
    }
}
