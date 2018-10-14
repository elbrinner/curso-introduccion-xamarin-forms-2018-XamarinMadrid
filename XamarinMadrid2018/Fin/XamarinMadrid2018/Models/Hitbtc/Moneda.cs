using System;
using Newtonsoft.Json;
using XamarinMadrid2018.Converters.Json;

namespace XamarinMadrid2018.Models.Hitbtc
{
    public class Moneda
    {
        [JsonProperty("ask"), JsonConverter(typeof(StringADoubleConverter))]
        public double PrecioCompra { get; set; }

        [JsonProperty("bid"), JsonConverter(typeof(StringADoubleConverter))]
        public double PrecioVenta { get; set; }

        [JsonProperty("last"), JsonConverter(typeof(StringADoubleConverter))]
        public double Anterior { get; set; }

        [JsonProperty("open"), JsonConverter(typeof(StringADoubleConverter))]
        public double Apertura { get; set; }

        [JsonProperty("low"), JsonConverter(typeof(StringADoubleConverter))]
        public double PrecioMasBajoDelDia { get; set; }

        [JsonProperty("high"), JsonConverter(typeof(StringADoubleConverter))]
        public double PrecioMasAltoDelDia { get; set; }

        [JsonProperty("volume"), JsonConverter(typeof(StringADoubleConverter))]
        public double Volume { get; set; }

        [JsonProperty("volumeQuote"), JsonConverter(typeof(StringADoubleConverter))]
        public double VolumeQuote { get; set; }

        public DateTime timestamp { get; set; }

        [JsonProperty("symbol")]
        public string NombreMoneda { get; set; }

        public string ImagenOperacion => this.CalcularEstado(PrecioCompra,Apertura);

        private string CalcularEstado(double precioCompra, double apertura)
        {
            if(precioCompra==apertura){
                return "igual";
            }else if(precioCompra > apertura){
                return "arriba";
            }else{
                return "abajo";
            }
        }
    }
}
