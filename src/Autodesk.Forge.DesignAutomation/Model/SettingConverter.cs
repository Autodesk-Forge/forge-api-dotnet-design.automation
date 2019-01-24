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
