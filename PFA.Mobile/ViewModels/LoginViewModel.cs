using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PFA.Mobile.Services;
using PFA.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA.Mobile.ViewModels
{
	internal partial class LoginViewModel:BaseViewModel
	{
		[ObservableProperty,NotifyPropertyChangedFor(nameof(IsLoginEnabled))]
		string surveillantLogin;
		[ObservableProperty,NotifyPropertyChangedFor(nameof(IsLoginEnabled))]
		string surveillantPassword;
		public bool IsLoginEnabled => 
			!string.IsNullOrEmpty(SurveillantLogin) && !string.IsNullOrEmpty(SurveillantPassword);
		[RelayCommand]
		public async Task Login()
		{
			this.IsBussy = true;
			try
			{
				var surveillant = await API.Client.LoginAsSurveillantAsync(this.SurveillantLogin, this.SurveillantPassword);
				if (surveillant != null)
					Application.Current.MainPage = new HomePage()
					{
						BindingContext=new HomePageViewModel(surveillant)
					};
				else
					await Shell.Current.DisplayAlert("Error", "Couldn't login\nPlease try again", "OK");
			}catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", "Couldn't login\nPlease try again", "OK");
			}
			this.IsBussy = true;
		}
	}
}
