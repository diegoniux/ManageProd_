using ManageProd.Models;
using ManageProd.Services.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Splat;
using Acr.UserDialogs;

namespace ManageProd.ViewModels
{
    public class LoginPageViewModel: BaseViewModel
    {
        public UserModel User { get; set; }
        public bool RememberUser { get; set; }
        public ICommand ExecuteLogin { get; set; }


        private IRoutingService _navigationService;

        public LoginPageViewModel(IRoutingService navigationService = null)
        {
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            ExecuteLogin = new Command(() => LoginAsync());
        }

        private async System.Threading.Tasks.Task LoginAsync()
        {
            try
            {
                if (User == null)
                {
                    throw new Exception("Favor de ingresar usuario y password");
                }
                if (string.IsNullOrWhiteSpace(User.User))
                {
                    throw new Exception("Favor de capturar el usuario");
                }
                if (string.IsNullOrWhiteSpace(User.Password))
                {
                    throw new Exception("Favor de capturar el password");
                }


                // This is where you would probably check the login and only if valid do the navigation...
                await _navigationService.NavigateTo("///main/home");
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(ex.Message,"Aviso","Ok");
                // await App.Current.MainPage.DisplayAlert("Aviso", ex.Message, "Ok");
            }
            
        }
            
    }
}
