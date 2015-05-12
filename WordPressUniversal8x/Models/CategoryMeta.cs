using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// base model for category meta
    /// </summary>
    public class CategoryMeta
    {
        /// <summary>
        /// gets the meta object links
        /// </summary>
        [JsonProperty("links")]
        public CategoryMetaLinks links { get; set; }
    }
}
