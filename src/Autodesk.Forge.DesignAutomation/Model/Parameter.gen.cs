/* 
 * Forge SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Design Automation
 *
 * Generated by [Forge Swagger Codegen](https://git.autodesk.com/forge-ozone/forge-rsdk-codegen)
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
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Forge.DesignAutomation.Rsdk.Model
{
    /// <summary>
    /// Parameter
    /// </summary>
    [DataContract]
    public partial class Parameter 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        public Parameter()
        {
        }
        
        /// <summary>
        /// The parameter references a zip file. This is how this is interpreted in various scenarios: 1. verb&#x3D;&#x3D;get implies that the byte stream should be unzipped to a folder designated by localName. 2. verb&#x3D;&#x3D;put, patch, post the contents of the file or folder designated by localName will be zipped and sent. 3. Any other verb values result in an error. Default is false.
        /// </summary>
        /// <value>The parameter references a zip file. This is how this is interpreted in various scenarios: 1. verb&#x3D;&#x3D;get implies that the byte stream should be unzipped to a folder designated by localName. 2. verb&#x3D;&#x3D;put, patch, post the contents of the file or folder designated by localName will be zipped and sent. 3. Any other verb values result in an error. Default is false.</value>
        [DataMember(Name="zip", EmitDefaultValue=false)]
        public bool Zip { get; set; }

        /// <summary>
        /// The parameter will be accessed by the appbundle on demand and should not be used by the system. Default is false.
        /// </summary>
        /// <value>The parameter will be accessed by the appbundle on demand and should not be used by the system. Default is false.</value>
        [DataMember(Name="ondemand", EmitDefaultValue=false)]
        public bool Ondemand { get; set; }

        /// <summary>
        /// Request method (get, put, patch or post).
        /// </summary>
        /// <value>Request method (get, put, patch or post).</value>
        [DataMember(Name="verb", EmitDefaultValue=false)]
        public Verb Verb { get; set; }

        /// <summary>
        /// The description of the parameter.
        /// </summary>
        /// <value>The description of the parameter.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Specifies whether the corresponding WorkItem Argument is required. Default is false.
        /// </summary>
        /// <value>Specifies whether the corresponding WorkItem Argument is required. Default is false.</value>
        [DataMember(Name="required", EmitDefaultValue=false)]
        public bool Required { get; set; }

        /// <summary>
        /// The file or folder where the contents of an UrlArgument are placed. Note that this may be different than the &#x60;localName&#x60; for input arguments when [Content-Disposition](http://www.w3.org/Protocols/rfc2616/rfc2616-sec19.html#sec19.5.1) header is specifified by the server. For &#x60;zip&#x60; &#x3D; &#x60;true&#x60; this is a folder name.
        /// </summary>
        /// <value>The file or folder where the contents of an UrlArgument are placed. Note that this may be different than the &#x60;localName&#x60; for input arguments when [Content-Disposition](http://www.w3.org/Protocols/rfc2616/rfc2616-sec19.html#sec19.5.1) header is specifified by the server. For &#x60;zip&#x60; &#x3D; &#x60;true&#x60; this is a folder name.</value>
        [DataMember(Name="localName", EmitDefaultValue=false)]
        public string LocalName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}