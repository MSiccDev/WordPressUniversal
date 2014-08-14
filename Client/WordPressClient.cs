using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using WordPressUniversal.Helpers;

namespace WordPressUniversal.Client
{
    public class WordPressClient
    {
        /// <summary>
        /// client to get the json string for posts or pages from WordPress
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="type">the post type based on the PostType enumeration</param>
        /// <param name="status">the post status based on the PostStatus enumeration</param>
        /// <param name="number">the number of posts to fetch (0-100). default value goes to 10.</param>
        /// <returns>the raw json string for posts or pages</returns>
        public async Task<string> getPosts(string site, PostType type, PostStatus status, int? number = null)
        {
            if (!number.HasValue)
            {
                number = 10;
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.IfModifiedSince = DateTime.Now;

            return await client.GetStringAsync(new Uri(Endpoints.posts(site, type, status, number)));
        }


        /// <summary>
        /// Wraps the returning posts into Post objects. Uses JSON.net for deserialization.
        /// </summary>
        /// <param name="site"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="number"></param>
        /// <returns>List<Post>, containing all posts that match the query</returns>
        public async Task<PostsList> getPostList(string site, PostType type, PostStatus status, int? number = null)
        {
            PostsList post_list = new PostsList();

            var response = await getPosts(site, type, status, number);

            if (response != null)
            {
                post_list = JsonConvert.DeserializeObject<PostsList>(response);
            }
            else
            {
                throw new NullReferenceException("response does not contain any data, please try again with different terms.");
            }

            return post_list;
        }







    }
}
