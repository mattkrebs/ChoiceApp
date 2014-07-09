using ChoiceApp.Services.Interfaces;
using ChoiceApp.Services.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceApp.Services
{
    public class AzureService
    {
        public MobileServiceClient MobileService { get; set; }
        private readonly IMobileServiceTable<Choice> dataTable;
        public AzureService()
        {

#if __ANDROID__ || __IOS__
     Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
#endif

            MobileService = new MobileServiceClient("https://choice.azure-mobile.net", "LYySSocSCOwiWgPKtkDYVdPggbZRhK26");
            dataTable = MobileService.GetTable<Choice>();
        }
        public Task InsertChoiceAsync(Choice expense)
        {

            return dataTable.InsertAsync(expense);
        }

        public Task UpdateChoiceAsync(Choice expense)
        {
            return dataTable.UpdateAsync(expense);
        }

        public Task<IEnumerable<Choice>> GetExpensesAsync()
        {
            return dataTable.ToEnumerableAsync();
        }


        static readonly AzureService instance = new AzureService();
        /// <summary>
        /// Gets the instance of the Azure Web Service
        /// </summary>
        public static AzureService Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
