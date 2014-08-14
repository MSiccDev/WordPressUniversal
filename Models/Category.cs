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
        public int id { get; set; }

        /// <summary>
        /// the category's name
        /// </summary>
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// the category's slug
        /// </summary>
        [JsonProperty("slug")]
        public string slug { get; set; }

        /// <summary>
        /// the category's description
        /// </summary>
        [JsonProperty("description")]
        public string description { get; set; }

        /// <summary>
        /// the post count within the category
        /// </summary>
        [JsonProperty("post_count")]
        public int count { get; set; }

        /// <summary>
        /// the category's parent
        /// </summary>
        [JsonProperty("parent")]
        public int parent { get; set; }

        /// <summary>
        /// the catgetory's meta
        /// </summary>
        public object meta { get; set; }

    }
}
