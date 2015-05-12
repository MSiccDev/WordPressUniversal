using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// contains links to get more meta information about the actual category
    /// </summary>
    public class CategoryMetaLinks
    {
        /// <summary>
        /// the API link to the actual category
        /// </summary>
        [JsonProperty("help")]
        public string self { get; set; }
        /// <summary>
        /// the API link to the actual category's help
        /// </summary>
        [JsonProperty("help")]
        public string help { get; set; }
        /// <summary>
        /// the API link to the actual category's site
        /// </summary>
        [JsonProperty("site")]
        public string site { get; set; }
    }
}
