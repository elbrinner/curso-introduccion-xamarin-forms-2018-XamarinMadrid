using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinMadrid2018.Models.Hitbtc;

namespace XamarinMadrid2018.Services.Hitbtc
{
    public interface IHitbtcWebService
    {
        Task<List<Moneda>> ListadoCotizacion();
    }
}
