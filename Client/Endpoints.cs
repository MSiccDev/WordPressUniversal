using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressUniversal.Models;

namespace WordPressUniversal.Client
{
    public class Endpoints
    {
        /// <summary>
        /// generates the url for all requests to fetch posts from WordPress
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="type">the post type based on the PostType enumeration</param>
        /// <param name="status">the post status based on the PostStatus enumeration</param>
        /// <param name="number">the number of posts to fetch (0-100). default value goes to 10.</param>
        /// <returns>the generated post url as string</returns>
        public static string posts(string site, PostType type, PostStatus status, int? number = null)
        {
            int postNumber = 10;

            if (number.HasValue)
            {
                postNumber = number.Value;
            }

            var postType = Enum.GetName(typeof(PostType), type).ToLowerInvariant();

            var postStatus = Enum.GetName(typeof(PostStatus), status).ToLowerInvariant();

            return string.Format("https://public-api.wordpress.com/rest/v1/sites/{0}/posts/?number={1}&type={2}&status={3}", site, postNumber, postType, postStatus);
                              
        }
    }
}
