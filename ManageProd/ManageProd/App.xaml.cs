using ManageProd.Services.Routing;
using ManageProd.ViewModels;
using ManageProd.Views;
using Splat;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManageProd
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public App()
        {
            InitializeDi();
            InitializeComponent();

            MainPage = new AppShell();
        }

        private void InitializeDi()
        {
            // Services
            Locator.CurrentMutable.RegisterLazySingleton<IRoutingService>(() => new ShellRoutingService());
            // Locator.CurrentMutable.RegisterLazySingleton<IIdentityService>(() => new IdentityServiceStub());

            // ViewModels
            // Locator.CurrentMutable.Register(() => new LoadingViewModel());
            Locator.CurrentMutable.Register(() => new LoginPageViewModel() { User = new Models.UserModel() });
            // Locator.CurrentMutable.Register(() => new RegistrationViewModel());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
