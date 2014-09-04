using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// declares the comment type that shall be fetched from the API
    /// </summary>
    public enum CommentType
    {
        /// <summary>
        /// Return all comments regardless of type. default type
        /// </summary>
        any = 0,
    
        /// <summary>
        /// Return only regular comments
        /// </summary>
        comment = 1, 

        /// <summary>
        /// Return only trackbacks
        /// </summary>
        trackback = 2,
    
        /// <summary>
        /// Return only pingbacks
        /// </summary>
        pingback = 3,
        
        /// <summary>
        /// Return both trackbacks and pingbacks
        /// </summary>
        pings = 4
    }
}
