using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordPressUniversal.Helpers;
using WordPressUniversal.Models;
using WordPressUniversal.Utils;

namespace WordPressUniversal.Client
{
    public class WordPressClient
    {
        #region internal methods
        #region posts and pages
        /// <summary>
        /// client to get the json string for posts or pages from WordPress
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="type">the post type based on the PostType enumeration</param>
        /// <param name="status">the post status based on the PostStatus enumeration</param>
        /// <param name="number">the number of posts to fetch (0-100). default value goes to 10.</param>
        /// <returns>the raw json string for posts or pages</returns>
        private async Task<string> getPosts(string site, PostType type, PostStatus status, int? number = null)
        {
            if (!number.HasValue)
            {
                number = 10;
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.IfModifiedSince = DateTime.Now;

            return await client.GetStringAsync(new Uri(postUrl(site, type, status, number)));
        }


        /// <summary>
        /// generates the url for all requests to fetch posts or pages from WordPress
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="type">the post type based on the PostType enumeration</param>
        /// <param name="status">the post status based on the PostStatus enumeration</param>
        /// <param name="number">the number of posts to fetch (0-100). default value goes to 10.</param>
        /// <returns>the generated post url as string</returns>
        private static string postUrl(string site, PostType type, PostStatus status, int? number = null)
        {
            if (!number.HasValue)
            {
                number = 10;
            }

            var postType = Enum.GetName(typeof(PostType), type).ToLowerInvariant();

            var postStatus = Enum.GetName(typeof(PostStatus), status).ToLowerInvariant();

            return string.Format("https://public-api.wordpress.com/rest/v1/sites/{0}/posts/?number={1}&type={2}&status={3}", site, number, postType, postStatus);

        }
        #endregion

        #region categories
        /// <summary>
        /// client to get the json string for categories of a WordPress site
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="number">The number of categories to return. Limit: 1000. Default: 100.</param>
        /// <returns>raw json string for categories</returns>
        private async Task<string> getCatgeories(string site, int? number = null)
        {
            if (!number.HasValue)
            {
                number = 100;
            }

             HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.IfModifiedSince = DateTime.Now;

            return await client.GetStringAsync(new Uri(categoriesUrl(site, number)));
        }

        /// <summary>
        /// generates the url to fetch cetegories of a site
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="number">The number of categories to return. Limit: 1000. Default: 100.</param>
        /// <returns>the generated url for fetching categories as string</returns>
        private static string categoriesUrl(string site, int? number = null)
        {
            if (!number.HasValue)
            {
                number = 100;
            }

            return string.Format("https://public-api.wordpress.com/rest/v1/sites/{0}/categories/?number={1}", site, number);
        }
        #endregion

        #endregion






        #region public methods
        /// <summary>
        /// Wraps the returning posts into Post objects. Uses JSON.net for deserialization.
        /// </summary>
        /// <param name="site"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="number"></param>
        /// <returns>List of all posts that match the query</returns>
        public async Task<PostsList> GetPostList(string site, PostType type, PostStatus status, int? number = null)
        {
            PostsList post_list = new PostsList();

            var response = await getPosts(site, type, status, number);

            if (response != null)
            {
                post_list = JsonConvert.DeserializeObject<PostsList>(response);

                foreach (var item in post_list.posts_list)
                {
                    //getting categories as string but handled as object to keep deserializing of posts possible
                    if (item.categories != null)
                    {
                        var cat_object = item.categories;
                        item.categories = PostCategories.GetString(cat_object);
                    }

                    //getting tags as string but handled as object to keep deserializing of posts possible
                    if (item.tags != null)
                    {
                        var tags_object = item.tags;
                        item.tags = PostTags.GetString(tags_object);
                    }

                    //getting attachments as string but handled as object to keep deserializing of posts possible
                    if (item.attachements != null)
                    {
                        var attachments_obj = item.attachements;
                        item.attachements = PostAttachments.GetList(attachments_obj);
                    }
                }
            }
            else
            {
                throw new NullReferenceException("response is empty");
            }

            return post_list;
        }

        public async Task<CategoriesList> GetCategoriesList(string site, int? number = null)
        {
            CategoriesList categories_list = new CategoriesList();

            var response = await getCatgeories(site, number);

            if (response != null)
            {
                categories_list = JsonConvert.DeserializeObject<CategoriesList>(response);
            }
            else
            {
                throw new NullReferenceException("response is empty");
            }
            return categories_list;
        }

        #endregion







    }
}
