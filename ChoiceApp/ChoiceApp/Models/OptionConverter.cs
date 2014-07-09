using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChoiceApp.Shared.Models
{
    public class OptionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Option[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var optionAsString = serializer.Deserialize<string>(reader);

            return optionAsString == null ? null : JsonConvert.DeserializeObject<Option[]>(optionAsString);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var optionAsString = JsonConvert.SerializeObject(value);
            serializer.Serialize(writer, optionAsString);
        }
    }
}
