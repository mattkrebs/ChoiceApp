using ChoiceApp.Shared.Models;
using ChoiceApp.Shared.Models.ViewModels;
using ChoiceApp.Shared.Services;
using ChoiceApp.Shared.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ChoiceApp.Shared.Pages
{
    public class ChoicesPage : CarouselPage
    {
        private List<ChoicePage> Choices;
        ChoiceServices db = new ChoiceServices();

        public ChoiceListViewModel ViewModel
        {
            get { return BindingContext as ChoiceListViewModel; }
            set { BindingContext = value; }
        }

        private Image image1;
        private Image image2;

        public ChoicesPage()
        {
            this.Title = "Choices";
            this.CurrentPage = new ContentPage();
            NavigationPage.SetHasNavigationBar (this, true);
            ViewModel = new ChoiceListViewModel();


        }

     

        protected override async void OnAppearing()
        {
            base.OnAppearing();
           
                //ViewModel.LoadChoices.Execute(null);
            var choices = await ChoiceServices.Instance.GetChoices();
            this.ItemsSource = choices;
            this.ItemTemplate = new DataTemplate(() =>
            {
                return new ChoicePage();
            });

            

            
        }

      
    }
}
