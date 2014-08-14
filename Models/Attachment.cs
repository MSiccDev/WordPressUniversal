using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// data of a post's attachment
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// the attachment's id
        /// </summary>
        [JsonProperty("ID")]
        public int id { get; set; }

        /// <summary>
        /// the attachment's url
        /// </summary>
        [JsonProperty("URL")]
        public string url { get; set; }


        /// <summary>
        /// the attachment's guid
        /// </summary>
        [JsonProperty("guid")]
        public string guid { get; set; }

        /// <summary>
        /// the attachment's mime type as string
        /// </summary>
        [JsonProperty("mime_type")]
        public string mime_type { get; set; }

        /// <summary>
        /// the attachment's width (0 for non image attachments)
        /// </summary>
        [JsonProperty("width")]
        public int width { get; set; }

        /// <summary>
        /// the attachment's height (0 for non image attachments)
        /// </summary>
        [JsonProperty("height")]
        public int height { get; set; }
    
    }
}
