using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace Autodesk.Forge.DesignAutomation.Model
{
    public class ArgumentConverter : Newtonsoft.Json.Converters.CustomCreationConverter<IArgument>
    {
        public override IArgument Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                IArgument target;
                var jObject = JObject.Load(reader);
                if (jObject.Property("url") != null)
                {
                    target = new XrefTreeArgument();
                }
                else
                {
                    target = new StringArgument();
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
