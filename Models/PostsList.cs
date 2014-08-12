using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// List of posts returned by the API
    /// </summary>
    public class PostsList
    {
        /// <summary>
        /// The total number of posts found that match the request (ignoring limits, offsets and pagination).
        /// </summary>
        [JsonProperty("found")]
        public int posts_total_count { get; set; }

        /// <summary>
        /// List of posts that match the request (including limits, offsets and pagination).
        /// </summary>
        [JsonProperty("posts")]
        public List<Post> posts_list { get; set; }


    }
}
