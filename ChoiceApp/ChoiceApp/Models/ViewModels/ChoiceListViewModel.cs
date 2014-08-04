using ChoiceApp.Shared.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChoiceApp.Shared.Models.ViewModels
{
    public class ChoiceListViewModel : BaseViewModel
    {
        public bool Initilized { get; set; }

        public ObservableCollection<Choice> Choices { get; set; }

        public ChoiceListViewModel()
        {
            Choices = new ObservableCollection<Choice>();
            



            ////Subscibe to insert expenses
            //MessagingCenter.Subscribe<TripExpense>(this, "NewExpense", (expense) =>
            //{
            //    Expenses.Add(expense);
            //});

            ////subscribe to update expenxes
            //MessagingCenter.Subscribe<TripExpense>(this, "UpdateExpense", (expense) =>
            //{
            //    ExecuteUpdateExpense(expense);
            //});


        }

       

        


        private Command loadChoices;

        public ICommand LoadChoices
        {
            get
            {
                return loadChoices ??
                    (loadChoices = new Command(async () => await ExecuteLoadChoices()));
            }
        }


        private async Task ExecuteLoadChoices()
        {
            Initilized = true;
            IsBusy = true;

            Choices.Clear();

            var choices = await ChoiceServices.Instance.GetChoices();
            foreach (var choice in choices)
                Choices.Add(choice);
            IsBusy = false;
        }


        private Command<Choice> updateExpense;
        public ICommand UpdateChoices
        {
            get
            {
                return updateExpense ??
                (updateExpense = new Command<Choice>(ExecuteUpdateExpense));
            }
        }

        private void ExecuteUpdateExpense(Choice expense)
        {
            IsBusy = true;
            var index = Choices.IndexOf(expense);
            Choices[index] = expense;
            IsBusy = false;
        }





    }
}
