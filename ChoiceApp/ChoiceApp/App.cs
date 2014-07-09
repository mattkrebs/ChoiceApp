using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ChoiceApp.Shared.Models;
using System.Reflection;
using System.IO;
using ChoiceApp.Shared.Pages;

namespace ChoiceApp
{
	public static class App
	{
        public static Page GetMainPage()
        {
            return new RootPage();
           
        }
       
	}
}
