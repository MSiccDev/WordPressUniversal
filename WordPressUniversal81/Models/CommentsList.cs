using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// base model for List of comments returned by the API
    /// </summary>
    public class CommentsList
    {
        /// <summary>
        /// total number of comments of a site or post
        /// </summary>
        [JsonProperty("found")]
        public int comments_total_count { get; set; }

        /// <summary>
        /// list of comments returned by the request (including limits, offsets and pagination) 
        /// </summary>
        [JsonProperty("comments")]
        public List<Comment> commentsList { get; set; }
    }
}
