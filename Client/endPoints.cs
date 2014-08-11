using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressUniversal.Models;

namespace WordPressUniversal.Client
{
    public class EndPoints
    {

        public string postsUrl(string site, PostType type, PostStatus status, int? number = null)
        {
            int postNumber = 10;
            if (number != null)
            {
                postNumber = Convert.ToInt32(number);
            }
            var postType = Enum.GetName(typeof(PostType), type).ToLower();

            var postStatus = Enum.GetName(typeof(PostStatus), status).ToLower();

            return string.Format("https://public-api.wordpress.com/rest/v1/sites/{0}/posts/?number={1}&type={2}&status={3}", site, number, postType, postStatus);
                              
        }
    }
}
