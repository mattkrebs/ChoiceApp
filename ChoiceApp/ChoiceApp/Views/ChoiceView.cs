using ChoiceApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoiceApp.Shared.Views
{
    public class ChoiceView : StackLayout
    {
        public Image Option1 { get; set; }
        public Image Option2 { get; set; }

        public ChoiceView(Choice choice)
        {
            if (Option1 == null)
                Option1 = new Image();
            if (Option2 == null)
                Option2 = new Image();

            Option1.Source = ImageSource.FromUri(new Uri(choice.Option1.ImageUrl));
            Option2.Source = ImageSource.FromUri(new Uri(choice.Option2.ImageUrl));

            Children.Add(Option1);
            Children.Add(Option2);
            

        }
    }
}
