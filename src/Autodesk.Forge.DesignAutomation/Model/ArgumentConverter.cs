/* 
 * Forge SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Design Automation
 *
  * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            IArgument target;
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject jObject = JObject.Load(reader);
                if (jObject["url"] != null)
                {
                    target = new XrefTreeArgument();
                    serializer.Populate(jObject.CreateReader(), target);
                }
                else if (jObject["value"] != null)
                {
                    target = new StringArgument(jObject["value"].Value<string>());
                }
                else
                {
                    if (jObject["uploadJobFolder"] != null)
                    {
                        target = new StringArgument(jObject.ToString(Formatting.None));
                    }
                    else
                    {
                        throw new JsonSerializationException($"Expected XrefTreeArgument or StringArgument.");
                    }
                }
            }
            else if (reader.TokenType == JsonToken.String)
            {
                target = new StringArgument(reader.Value.ToString());
            }
            else
            {
                throw new JsonReaderException($"Expected object or string but got {reader.TokenType}.");
            }

            return target;
        }
    }
}
