using ManageProd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManageProd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPageViewModel LoginViewModel { get; set; }
        public LoginPage()
        {
            InitializeComponent();

            LoginViewModel = new LoginPageViewModel()
            {
                User = new Models.UserModel(),
                RememberUser = true
            };

            this.BindingContext = LoginViewModel;
        }

        async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (LoginViewModel.User.User == LoginViewModel.User.User && LoginViewModel.User.User != string.Empty)
                {
                    App.IsUserLoggedIn = true;
                    await Shell.Current.GoToAsync("//main");
                    
                }
                else
                {
                    throw new Exception("Usuario y/o contraseña incorrecta.");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Aviso", ex.Message, "Ok");
            }
            
        }
    }
}