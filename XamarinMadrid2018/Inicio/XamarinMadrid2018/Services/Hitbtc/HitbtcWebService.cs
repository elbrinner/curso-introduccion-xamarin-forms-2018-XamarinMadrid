using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinMadrid2018.Models.Hitbtc;

namespace XamarinMadrid2018.Services.Hitbtc
{
    public class HitbtcWebService : IHitbtcWebService 
    {
        
        public async Task<List<Moneda>>  ListadoCotizacion()
        {

            try
            {
                string url = XamarinMadrid2018.Contants.ConfigConstants.LISTADO_COTIZACION_ACTUAL;

                HttpClient client = new HttpClient();
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {

                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        return JsonConvert.DeserializeObject<List<Moneda>>(content);
                    }
                }
            }
            catch (Exception ex)
            {
                //ignore
            }
           

            return null;


        }
    }
}
