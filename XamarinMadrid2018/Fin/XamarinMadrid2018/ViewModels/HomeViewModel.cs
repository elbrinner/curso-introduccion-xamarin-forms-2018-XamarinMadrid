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

        private List<Moneda> listCoin;
        private Moneda seletedListCoin;
      
        public List<Moneda> ListCoin
        {
            get{
                return this.listCoin;
            }
            set
            {
                this.listCoin = value;
                this.OnPropertyChanged();
            }
        }

        public Moneda SeletedListCoin
        {
            get
            {
                return this.seletedListCoin;
            }    
            set
            {
                this.seletedListCoin = value;
                this.NavigateDetail(value);
                this.OnPropertyChanged();
            }
        }

        private void NavigateDetail(Moneda value)
        {
            if(value!=null){
                this.navigationService.NavigateToAsync<DetailViewModel>(value);
            }
        }

        public override async Task VMAppearingAsync(object parameter)
        {
            this.TitlePage = "Xamarin Madrid - Hitbtc";

            if(!CrossConnectivity.Current.IsConnected){
                DependencyService.Get<IDialogService>().ShowAlert("Error", "Sin conexión", "Aceptar");
                return;
            }

             if(this.listCoin==null){
                try
                {
                    this.IsBusy = true;
                    await Task.Delay(3000); //Para que se vea el cargando.

                    var response = await hitbtcService.ListadoCotizacion();
                    if (response != null)
                    {
                        this.ListCoin = response.Where(p => p.NombreMoneda.Contains("USD")).OrderByDescending(a=> a.VolumeQuote).ToList(); //quiero solo las monedas que cotizán
                    }
                    else
                    {
                        DependencyService.Get<IDialogService>().ShowAlert("Error", "Error del servicio", "Aceptar");
                    }
                }
                catch (Exception ex)
                {
                    DependencyService.Get<IDialogService>().ShowAlert("Error", ex.Message, "Aceptar");
                }
                finally
                {
                    this.IsBusy = false;   
                }
            }
          
        }
    }
}
