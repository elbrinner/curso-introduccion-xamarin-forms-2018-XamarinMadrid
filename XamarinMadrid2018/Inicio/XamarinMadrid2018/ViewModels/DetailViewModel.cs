using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XamarinMadrid2018.Models.Hitbtc;
using XamarinMadrid2018.Services.Hitbtc;
using XamarinMadrid2018.Services.Navigation;
using Syncfusion.SfChart;
using XamarinMadrid2018.Models;
using Syncfusion.SfChart.XForms;

namespace XamarinMadrid2018.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        public DetailViewModel(INavigationService navigationService, IHitbtcWebService hitbtcService) : base(navigationService, hitbtcService)
        {
        }

        public ObservableCollection<ChartDataModel> ColumnData1 { get; set; }

        public ObservableCollection<ChartDataModel> ColumnData2 { get; set; }

        public ObservableCollection<ChartDataModel> ColumnData3 { get; set; }

        public ObservableCollection<ChartDataModel> ColumnData4 { get; set; }

        public ObservableCollection<ChartDataModel> ColumnData5 { get; set; }

        public ObservableCollection<ChartDataModel> ColumnData6 { get; set; }



     
        public override Task VMViewDidLoad(object parameter)
        {
            Moneda param =  parameter as Moneda;

           
           this.TitlePage = "Info de " + param.NombreMoneda;

            ColumnData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(param.NombreMoneda, param.Anterior),
            };


            ColumnData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(param.NombreMoneda, param.Apertura),

            };

            ColumnData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(param.NombreMoneda, param.PrecioCompra),
            };

            ColumnData4 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(param.NombreMoneda, param.PrecioVenta),
            };

            ColumnData5 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(param.NombreMoneda, param.PrecioMasBajoDelDia),
            };

            ColumnData6 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(param.NombreMoneda, param.PrecioMasAltoDelDia),
            };

            return base.VMAppearingAsync(parameter);
        }
    }
}
