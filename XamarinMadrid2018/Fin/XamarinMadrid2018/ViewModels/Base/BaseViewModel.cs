using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMadrid2018.Services.Hitbtc;
using XamarinMadrid2018.Services.Navigation;

namespace XamarinMadrid2018.ViewModels
{
    public class BaseViewModel : BindableObject
    {
        protected INavigationService navigationService;
        protected IHitbtcWebService hitbtcService;

        public BaseViewModel(INavigationService navigationService,IHitbtcWebService hitbtcService)
        {
            this.navigationService = navigationService;
            this.hitbtcService = hitbtcService;
        }

        public virtual Task VMAppearingAsync(object parameter)
        {
            return Task.FromResult(false);
        }

        public virtual Task VMDisappearing()
        {
            return Task.FromResult(false);
        }

        public virtual Task VMViewDidLoad(object parameter)
        {
            return Task.FromResult(false);
        }

        public virtual Task VMViewWillAppear(object parameter)
        {
            return Task.FromResult(false);
        }

        protected bool isBusy;
        protected string titlePage;

        public string TitlePage
        {
            get
            {
                return this.titlePage;
            }

            set
            {
                this.titlePage = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                this.isBusy = value;
                this.OnPropertyChanged();
            }
        }

       
    }
}
