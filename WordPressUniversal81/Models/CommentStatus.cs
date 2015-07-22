using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// used to declare the status of the comments that shall be fetched from the API
    /// </summary>
    public enum CommentStatus
    {
        /// <summary>
        /// Return only approved comments, default
        /// </summary>
        approved = 0,

        /// <summary>
        /// Return only comments in the moderation queue
        /// </summary>
        unapproved = 1,

        /// <summary>
        /// Return only comments marked as spam
        /// </summary>
        spam = 2,
        /// <summary>
        /// Return only comments in the trash
        /// </summary>
        trash = 3,

        /// <summary>
        /// Return comments of all statuses
        /// </summary>
        all = 4

    }
}
