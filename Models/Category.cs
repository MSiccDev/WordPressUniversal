using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Helpers
{
    public class Category
    {
        /// <summary>
        /// the category's id
        /// </summary>
        [JsonProperty("ID")]
        public int category_id { get; set; }

        /// <summary>
        /// the category's name
        /// </summary>
        [JsonProperty("name")]
        public string category_name { get; set; }

        /// <summary>
        /// the category's slug
        /// </summary>
        [JsonProperty("slug")]
        public string category_slug { get; set; }

        /// <summary>
        /// the category's description
        /// </summary>
        [JsonProperty("description")]
        public string description { get; set; }

        /// <summary>
        /// the post count within the category
        /// </summary>
        [JsonProperty("post_count")]
        public int category_post_count { get; set; }

        /// <summary>
        /// the category's parent
        /// </summary>
        [JsonProperty("parent")]
        public int category_parent { get; set; }

        /// <summary>
        /// the catgetory's meta
        /// </summary>
        public object category_meta { get; set; }

    }
}
