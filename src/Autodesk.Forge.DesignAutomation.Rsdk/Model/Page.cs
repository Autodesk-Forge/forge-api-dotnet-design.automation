using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Autodesk.Forge.DesignAutomation.Model
{
    /// <summary>
    /// PageAlias
    /// </summary>
    [DataContract]
    public class Page<T>
    {
        /// <summary>
        /// Gets or Sets PaginationToken
        /// </summary>
        [DataMember(Name = "paginationToken", EmitDefaultValue = false)]
        public string PaginationToken { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public List<T> Data { get; set; }

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

