using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Helpers
{
    /// <summary>
    /// provides the PostType that can be fetchted from WordPress
    /// </summary>
   public enum PostType
   {
       /// <summary>
       /// delivers only blog posts
       /// </summary>
       post = 0,
       /// <summary>
       /// delivers only blog pages
       /// </summary>
       page = 1,
       /// <summary>
       /// delivers any kind of post type
       /// </summary>
       any = 2
   }
}
