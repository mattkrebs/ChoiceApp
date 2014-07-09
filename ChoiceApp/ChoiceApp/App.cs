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
		static NavigationPage _NavPage;

        public static Page GetMainPage()
        {
			var profilePage = new RootPage ();
			_NavPage = new NavigationPage (profilePage);
			return _NavPage;
           
        }
		public static bool IsLoggedIn{
			get{ return !string.IsNullOrWhiteSpace (_Token); }
		}
		static string _Token;

		public static string Token{
			get { return _Token; }
		}

		public static void SaveToken(string token){
			_Token = token;
		}

		public static Action SuccessfulLoginAction{
			get{
				return new Action (() => {
					_NavPage.Navigation.PopModalAsync();
				});
			}
		}
	}
}
