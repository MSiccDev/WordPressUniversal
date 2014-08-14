using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Helpers
{
    public enum PostStatus
    {
        /// <summary>
        /// Return only published posts
        /// </summary>
        publish,

        /// <summary>
        /// Return only private posts
        /// </summary>
        //private,

        /// <summary>
        /// Return only draft posts
        /// </summary>
        draft,

        /// <summary>
        /// Return only posts pending editorial approval
        /// </summary>
        pending,

        /// <summary>
        /// Return only posts scheduled for future publishing
        /// </summary>
        future,

        /// <summary>
        /// Return only posts in the trash
        /// </summary>
        trash,

        /// <summary>
        /// Return all posts regardless of status
        /// </summary>
        any
    }
}
