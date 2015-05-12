using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal
{
    public class Author
    {

        /// <summary>
        /// The author's id.
        /// </summary>
        [JsonProperty("ID")]
        public int id { get; set; }

        /// <summary>
        /// the author's login name
        /// </summary>
        [JsonProperty("login")]
        public string login { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("email")]
        public bool email { get; set; }

        /// <summary>
        /// the author's name
        /// </summary>
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// the author's nice name
        /// </summary>
        [JsonProperty("nice_name")]
        public string nice_name { get; set; }

        /// <summary>
        /// the author's website
        /// </summary>
        [JsonProperty("URL")]
        public string website { get; set; }

        /// <summary>
        /// the author's avatar url 
        /// </summary>
        [JsonProperty("avatar_URL")]
        public string avatar_url { get; set; }

        /// <summary>
        /// the author's profile url
        /// </summary>
        [JsonProperty("profile_URL")]
        public string profile_url { get; set; }

        /// <summary>
        /// the site ID for this author object
        /// </summary>
        [JsonProperty("site_ID")]
        public int site_id { get; set; }


    }
}
