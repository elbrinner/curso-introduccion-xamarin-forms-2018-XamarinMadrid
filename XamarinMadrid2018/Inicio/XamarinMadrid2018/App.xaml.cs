using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMadrid2018.Pages;
using XamarinMadrid2018.Services.Navigation;
using XamarinMadrid2018.ViewModels.Base;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinMadrid2018
{
    public partial class App : Application
    {
        private INavigationService navigationService;

        public App()
        {
            InitializeComponent();

            MainPage = new HomePage();
        }

        protected override  async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private Task InitNavigation()
        {
            navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }
    }
}
