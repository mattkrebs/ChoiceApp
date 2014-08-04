using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceApp.Shared.Services
{
    public interface IMobileClient
    {
           Task<MobileServiceUser> Authorize(MobileServiceAuthenticationProvider provider);

            void Logout();
    }
}
