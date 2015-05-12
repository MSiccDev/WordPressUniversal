using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// meta data base class
    /// </summary>
    public class MetaData
    {
        /// <summary>
        /// the meta data item id
        /// </summary>
        [JsonProperty("id")]
        public string id { get; set; }

        /// <summary>
        /// the meta data item key
        /// </summary>
        [JsonProperty("key")]
        public string key { get; set; }

        /// <summary>
        /// the meta data item value
        /// </summary>
        [JsonProperty("value")]
        public string value { get; set; }
    }
}
