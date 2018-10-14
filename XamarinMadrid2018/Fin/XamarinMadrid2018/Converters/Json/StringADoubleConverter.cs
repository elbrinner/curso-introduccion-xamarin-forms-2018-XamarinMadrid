using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XamarinMadrid2018.Converters.Json
{
    public class StringADoubleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(double) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JToken token = JToken.Load(reader);

                string valor = token.ToObject<string>();

                double res = 0;
                double.TryParse(valor, System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out res);

                return res;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
