using ChoiceApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChoiceApp.Shared.Pages
{
    public class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            Label header = new Label
            {
                Text = "Choice",
                Font = Font.BoldSystemFontOfSize(30),
                HorizontalOptions = LayoutOptions.Center
            };




           // var choices = AzureService.Instance.GetExpensesAsync();
            //Load Children Choices
            this.Master = new ContentPage()
            {
                BackgroundColor = Color.Blue
            };

            var newChoice = new Button
            {
                Text = "New Choice"
            };

            newChoice.Clicked += async (sender, args) =>
            {
                await SeedChoices();
            };

            this.Detail = new ContentPage(){
                BackgroundColor = Color.Red,
                Content = new StackLayout()
                {
                    Children =
                    {
                        newChoice
                    }
                }
            };
           
        }

        public async Task SeedChoices()
        {
            var option1 = new Option(){ ImageUrl ="http://jztours.com/wp-content/uploads/2014/05/minnesota-vikings-logo.jpg", Id = Guid.NewGuid().ToString(), Name= "Vikings"};
            var option2 = new Option() { ImageUrl = "http://bestclipartblog.com/clipart-pics/packers-clip-art-2.jpg", Id = Guid.NewGuid().ToString(), Name = "Packers" };
            var options = new List<Option>(){ option1,option2};
            Choice c = new Choice()
            {
                Id = Guid.NewGuid().ToString(),
                Lat = 45.0,
                Lng = -93.5,                
                Tags = "#NFL",
                Options = options.ToArray()
            };
            

            //await AzureService.Instance.InsertChoiceAsync(c);
        }

      
    }
}
