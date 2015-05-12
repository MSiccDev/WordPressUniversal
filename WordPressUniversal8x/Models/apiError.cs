using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// base model for API errors
    /// </summary>
    public class apiError
    {
        /// <summary>
        /// the API error code
        /// </summary>
        [JsonProperty("error")]
        public string error { get; set; }

        /// <summary>
        /// the API error message
        /// </summary>
        [JsonProperty("message")]
        public string message { get; set; }
    }
}
