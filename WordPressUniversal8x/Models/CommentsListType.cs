using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// used to differ between sites comments and post comments
    /// </summary>
    public enum CommentsListType
    {
        /// <summary>
        /// for returning recent comments list of a site
        /// </summary>
        site = 0,
        /// <summary>
        /// for returning recent comments of a specific post
        /// </summary>
        post = 1
    }
}
