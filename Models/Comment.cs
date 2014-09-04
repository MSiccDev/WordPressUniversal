using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// base model for single comment
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// the comment's id
        /// </summary>
        [JsonProperty("ID")]
        public int comment_id { get; set; }

        /// <summary>
        /// the post object the comment belongs to
        /// </summary>
        [JsonProperty("post")]
        public Post post { get; set; }

        /// <summary>
        /// the comment's author
        /// </summary>
        [JsonProperty("author")]
        public Author author { get; set; }

        /// <summary>
        /// the comment's date
        /// </summary>
        [JsonProperty("date")]
        public string date { get; set; }

        /// <summary>
        /// the comment's url
        /// </summary>
        [JsonProperty("URL")]
        public string comment_url { get; set; }

        /// <summary>
        /// the comment's short url
        /// </summary>
        [JsonProperty("short_URL")]
        public string comment_short_url { get; set; }

        /// <summary>
        /// the comment's content in HTML format
        /// </summary>
        [JsonProperty("content")]
        public string content { get; set; }

        /// <summary>
        /// the comment's status
        /// </summary>
        [JsonProperty("status")]
        public string status { get; set; }
        
        /// <summary>
        /// the comment's parent
        /// </summary>
        [JsonProperty("parent")]
        public object parent { get; set; }
        
        /// <summary>
        /// the comment's type
        /// </summary>
        [JsonProperty("type")]
        public string type { get; set; }

        /// <summary>
        /// the comment's meta
        /// </summary>        
        [JsonProperty("meta")]
        public CommentyMeta commnet_meta { get; set; }
    }
}
