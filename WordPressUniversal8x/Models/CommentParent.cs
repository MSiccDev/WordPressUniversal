using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// base model for a comment's possible parent comment
    /// </summary>
    public class CommentParent
    {
        /// <summary>
        /// the parent comment's id
        /// </summary>
        [JsonProperty("ID")]
        public int parent_id { get; set; }

        /// <summary>
        /// the parent comment's type
        /// </summary>
        [JsonProperty("type")]
        public string type { get; set; }

        /// <summary>
        /// the parent comment's API link
        /// </summary>
        [JsonProperty("link")]
        public string link { get; set; }
    }
}
