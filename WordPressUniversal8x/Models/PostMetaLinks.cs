using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// contains links to get more meta information about the actual post
    /// </summary>
    public class PostMetaLinks
    {
        /// <summary>
        /// the API link to the actual post
        /// </summary>
        [JsonProperty("self")]
        public string self { get; set; }

        /// <summary>
        /// the API link to the actual post's help
        /// </summary>
        [JsonProperty("help")]
        public string help { get; set; }

        /// <summary>
        /// the API link to the actual post's site
        /// </summary>
        [JsonProperty("site")]
        public string site { get; set; }

        /// <summary>
        /// the API link to the actual post's replies
        /// </summary>
        [JsonProperty("replies")]
        public string replies { get; set; }

        /// <summary>
        /// the API link to the actual post's likes
        /// </summary>
        [JsonProperty("likes")]
        public string likes { get; set; }
    }
}
