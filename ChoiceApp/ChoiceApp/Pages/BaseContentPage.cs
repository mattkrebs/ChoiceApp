using System;
using Xamarin.Forms;
using ChoiceApp.Shared;

namespace ChoiceApp.Shared.Pages
{
	public class BaseContentPage : ContentPage
	{

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (!App.IsLoggedIn) {
				Navigation.PushModalAsync (new LoginOptions ());
			}
		}
	}
}

