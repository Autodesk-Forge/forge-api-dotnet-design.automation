using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace Autodesk.Forge.DesignAutomation.Model
{
    public class SettingConverter : CustomCreationConverter<ISetting>
    {
        public override ISetting Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                ISetting target;
                JObject jObject = JObject.Load(reader);
                if (jObject.Property("url") != null)
                {
                    target = new UrlSetting();
                }
                else
                {
                    target = new StringSetting();
                }
                serializer.Populate(jObject.CreateReader(), target);
                return target;
            }
            else
            {
                throw new JsonReaderException("Expected start of object.");
            }
        }
    }
}
