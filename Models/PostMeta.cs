using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    public class PostMeta
    {
        /// <summary>
        /// gets the meta object links
        /// </summary>
        [JsonProperty("links")]
        public PostMetaLinks links { get; set;}
    }
}
