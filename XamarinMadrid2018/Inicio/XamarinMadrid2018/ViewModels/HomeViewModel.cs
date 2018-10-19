using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMadrid2018.Models.Hitbtc;
using XamarinMadrid2018.Services.Hitbtc;
using XamarinMadrid2018.Services.Navigation;
using XamarinMadrid2018.Services.SpecificPlataform;
using Plugin.Connectivity;

namespace XamarinMadrid2018.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(INavigationService navigationService, IHitbtcWebService hitbtcService) : base(navigationService, hitbtcService)
        {
            
        }

       

    }
}
