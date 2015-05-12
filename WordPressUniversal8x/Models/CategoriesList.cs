using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// base model for List of categories returned by the API
    /// </summary>
    public class CategoriesList
    {
        /// <summary>
        /// The total number of categories found that match the request (ignoring limits, offsets and pagination).
        /// </summary>
        [JsonProperty("found")]
        public int categories_total_count { get; set; }

        /// <summary>
        /// List of categories that match the request (including limits, offsets and pagination).
        /// </summary>
        [JsonProperty("categories")]
        public List<Category> categories_list { get; set; }
    }
}
