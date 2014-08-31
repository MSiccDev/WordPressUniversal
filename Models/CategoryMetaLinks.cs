using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// contains links to get more meta information about the actual category
    /// </summary>
    public class CategoryMetaLinks
    {
        /// <summary>
        /// the API link to the actual category
        /// </summary>
        public string self { get; set; }
        /// <summary>
        /// the API link to the actual category's help
        /// </summary>
        public string help { get; set; }
        /// <summary>
        /// the API link to the actual category's site
        /// </summary>
        public string site { get; set; }
    }
}
