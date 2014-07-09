using ChoiceApp.Services.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceApp.Services.Repositories
{
    public class ChoiceRepository : BaseRepository<Choice>
    {
        public ChoiceRepository(IMobileServiceClient mobileServiceClient)
            : base(mobileServiceClient)
        {

        }
    }
}
