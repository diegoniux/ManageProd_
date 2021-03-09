using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageProd.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManageProd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

        }

        async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Usuario = new UserModel
                {
                    User = UserName.Text,
                    Password = PassworUser.Text
                };

                var isValid = AreCredentialsCorrect(Usuario);
                if (isValid)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    throw new Exception("Usuario y/o contraseña incorrecta");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Aviso", ex.Message, "Ok");
            }
        }

        bool AreCredentialsCorrect(UserModel user)
        {
            App.User = user;
            return user.User == user.User;
        }
    }
}