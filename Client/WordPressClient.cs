using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>the raw json string for posts or pages</returns>
        private async Task<string> getPosts(string site, PostType type, PostStatus status, int? number = null, int? offset = null)
        {
            if (!number.HasValue)
            {
                number = 10;
            }

            if (!offset.HasValue)
            {
                offset = 0;
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.IfModifiedSince = DateTime.Now;

            return await client.GetStringAsync(new Uri(postUrl(site, type, status, number, offset)));
        }


        /// <summary>
        /// generates the url for all requests to fetch posts or pages from WordPress
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="type">the post type based on the PostType enumeration</param>
        /// <param name="status">the post status based on the PostStatus enumeration</param>
        /// <param name="number">the number of posts to fetch (0-100). default value goes to 10.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>the generated post url as string</returns>
        private static string postUrl(string site, PostType type, PostStatus status, int? number = null, int? offset = null)
        {
            if (!number.HasValue)
            {
                number = 10;
            }

            if (!offset.HasValue)
            {
                offset = 0;
            }

            var postType = Enum.GetName(typeof(PostType), type).ToLowerInvariant();

            var postStatus = Enum.GetName(typeof(PostStatus), status).ToLowerInvariant();

            return string.Format("https://public-api.wordpress.com/rest/v1/sites/{0}/posts/?number={1}&offset={2}&type={3}&status={4}", site, number, offset, postType, postStatus);

        }
        #endregion

        #region categories
        /// <summary>
        /// client to get the json string for categories of a WordPress site
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="number">The number of categories to return. Limit: 1000. Default: 100.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>raw json string for categories</returns>
        private async Task<string> getCatgeories(string site, int? number = null, int? offset = null)
        {
            if (!number.HasValue)
            {
                number = 100;
            }

            if (!offset.HasValue)
            {
                offset = 0;
            }

             HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.IfModifiedSince = DateTime.Now;

            return await client.GetStringAsync(new Uri(categoriesUrl(site, number, offset)));
        }

        /// <summary>
        /// client to get the json string for posts in a category of a WordPress site
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="category">the category's name</param>
        /// <param name="type">the post type based on the PostType enumeration</param>
        /// <param name="status">the post status based on the PostStatus enumeration</param>
        /// <param name="number">the number of posts to fetch (0-100). default value goes to 10.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>raw json string for posts in a category</returns>
        private async Task<string> getCategoryPosts(string site, string category, PostType type, PostStatus status, int? number = null, int? offset = null)
        {
            if (!number.HasValue)
            {
                number = 10;
            }

            if (!offset.HasValue)
            {
                offset = 0;
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.IfModifiedSince = DateTime.Now;

            return await client.GetStringAsync(new Uri(categoryPostsUrl(site, category, type, status, number, offset)));
        }


        /// <summary>
        /// generates the url to fetch cetegories of a site
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="number">The number of categories to return. Limit: 1000. Default: 100.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>the generated url for fetching categories as string</returns>
        private static string categoriesUrl(string site, int? number = null, int? offset = null)
        {
            if (!number.HasValue)
            {
                number = 100;
            }

            if (!offset.HasValue)
            {
                offset = 0;
            }

            return string.Format("https://public-api.wordpress.com/rest/v1/sites/{0}/categories/?number={1}&offset={2}", site, number, offset);
        }
        

        /// <summary>
        /// generates the url for all requests to fetch posts in a category
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="category">the category's name</param>
        /// <param name="type">the post type based on the PostType enumeration</param>
        /// <param name="status">the post status based on the PostStatus enumeration</param>
        /// <param name="number">the number of posts to fetch (0-100). default value goes to 10.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>the generated category posts url as string</returns>
        private static string categoryPostsUrl(string site, string category, PostType type, PostStatus status, int? number = null, int? offset = null)
        {
            if (!number.HasValue)
            {
                number = 10;
            }

            if (!offset.HasValue)
            {
                offset = 0;
            }

            var postType = Enum.GetName(typeof(PostType), type).ToLowerInvariant();

            var postStatus = Enum.GetName(typeof(PostStatus), status).ToLowerInvariant();

            return string.Format("https://public-api.wordpress.com/rest/v1/sites/{0}/posts/?number={1}&offset={2}&category={3}&type={4}&status={5}", site, number, offset, category, postType, postStatus);

        }

        #endregion

        #region comments
        /// <summary>
        /// client to get json string of a site's or post's comments
        /// </summary>
        /// <param name="site_or_postid">the site url. insert without http:// prefix or the post id</param>
        /// <param name="listType">the type of comments list to fetch</param>
        /// <param name="type">the comments type to return</param>
        /// <param name="status">the comments status to return</param>
        /// <param name="number">The number of categories to return. Limit: 100. Default: 20.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>raw json string for comments of a site or post</returns>
        private async Task<string> getComments(string site, CommentsListType listType, CommentType type, CommentStatus status, string post_id = null, int? number = null, int? offset =null)
        {
            string url = string.Empty;

            if (!number.HasValue)
            {
                number = 20;
            }

            if (!offset.HasValue)
            {
                offset = 0;
            }

            if (listType == CommentsListType.site)
            {
                url = siteCommentsUrl(site, type, status, number, offset);
            }

            if (listType == CommentsListType.post)
            {
                url = postCommentsUrl(site, post_id, type, status, number, offset);
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.IfModifiedSince = DateTime.Now;

            return await client.GetStringAsync(new Uri(url));
        }


        /// <summary>
        /// used to generate the url for recent site comments
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="type">the comments type to return</param>
        /// <param name="status">the comments status to return</param>
        /// <param name="number">The number of comments to return. Limit: 100. Default: 20.</param>
        /// /// <returns>the generated url for fetching recent site comments</returns>
        private static string siteCommentsUrl(string site, CommentType type, CommentStatus status, int? number = null, int? offset = null)
        {
            if (!number.HasValue)
            {
                number = 100;
            }

            if (!offset.HasValue)
            {
                offset = 0;
            }

            return string.Format("https://public-api.wordpress.com/rest/v1/sites/{0}/comments/?number={1}&offset={2}&type={3}&status={4}", site, number, offset, type, status);

        }

        /// <summary>
        /// used to generate the url for a post's comments
        /// </summary>
        /// <param name="post_id">the post id for fetching the comments</param>
        /// <param name="type">the comments type to return</param>
        /// <param name="status">the comments status to return</param>
        /// <param name="number">The number of categories to return. Limit: 100. Default: 20.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>the generated url for fetching a post's comments</returns>
        private static string postCommentsUrl(string site, string post_id, CommentType type, CommentStatus status, int? number = null, int? offset = null)
        {
            if (!number.HasValue)
            {
                number = 100;
            }

            if (!offset.HasValue)
            {
                offset = 0;
            }

            return string.Format("https://public-api.wordpress.com/rest/v1/sites/{0}/posts/{1}/replies/?number={2}&offset={3}&type={4}&status={5}", site, post_id, number, offset, type, status);

        }
        #endregion

        #endregion






        #region public methods
        /// <summary>
        /// Wraps the returning posts into Post objects. Uses JSON.net for deserialization.
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="type">the type of posts that shall be returned (post or page)</param>
        /// <param name="status">the status of posts that shall be returned</param>
        /// <param name="number">the number of posts that shall be returned</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>List of all posts that matching the query</returns>
        public async Task<PostsList> GetPostList(string site, PostType type, PostStatus status, int? number = null, int? offset = null)
        {
            PostsList post_list = new PostsList();

            var response = await getPosts(site, type, status, number, offset);

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

                    //getting attachments as List but handled as object to keep deserializing of posts possible
                    if (item.attachements != null)
                    {
                        var attachments_obj = item.attachements;
                        item.attachements = PostAttachments.GetList(attachments_obj);
                    }

                    //getting metadata as List but handled as object to keep deserializing of posts possible
                    if (item.metadata != null)
                    {
                        var metadata_obj = item.metadata;
                        item.metadata = PostMetaData.GetList(metadata_obj);
                    }
                }
            }
            else
            {
                throw new NullReferenceException("response is empty");
            }

            return post_list;
        }


        /// <summary>
        /// Wraps the returning categories into category objects. Uses JSON.net for deserialization.
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="number">the number of categories that shall be returned. Limit: 1000. Default: 100.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>List of all categories matching the query</returns>
        public async Task<CategoriesList> GetCategoriesList(string site, int? number = null, int? offset = null)
        {
            CategoriesList categories_list = new CategoriesList();

            var response = await getCatgeories(site, number, offset);

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


        /// <summary>
        /// Wraps the returning comments into comment object. Uses JSON.net for deserialization.
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="listType">listType declares if site or post comments shall be returned</param>
        /// <param name="type">the type of comments that shall be returned</param>
        /// <param name="status">the status of the comments that shall be returned</param>
        /// <param name="post_id">the post_id of which comments shall be fetched</param>
        /// <param name="number">The number of comments to return. Limit: 100. Default: 20.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>List of all comments matching the query</returns>
        public async Task<CommentsList> GetCommentsList(string site, CommentsListType listType, CommentType type, CommentStatus status, string post_id= null, int? number = null, int? offset = null)
        {
            CommentsList comments_list = new CommentsList();

            var response = await getComments(site, listType, type, status, post_id, number, offset);

            if (response != null)
            {
                comments_list = JsonConvert.DeserializeObject<CommentsList>(response);

                foreach (var item in comments_list.comments)
                {
                    if (!item.parent.ToString().Contains("false"))
                    {
                        //try/catch is the only possible way to get around JsonReaderException, because parent is false not null if it has none
                        try
                        {
                            JObject par = (JObject)item.parent;
                            item.parent = new CommentParent()
                            {
                                parent_id = (int)par["ID"],
                                type = (string)par["type"],
                                link = (string)par["link"]
                            };
                        }
                        catch {
                            item.parent = null;
                        }
                    }

                    else
                    {
                        throw new NullReferenceException("response is empty");
                    }
                }
            }


            return comments_list;
        }

        /// <summary>
        /// Wraps the returning posts into Post objects. Uses JSON.net for deserialization.
        /// </summary>
        /// <param name="site">the site url. insert without http:// prefix</param>
        /// <param name="category">the category's name</param>
        /// <param name="type">the post type based on the PostType enumeration</param>
        /// <param name="status">the post status based on the PostStatus enumeration</param>
        /// <param name="number">the number of posts to fetch (0-100). default value goes to 10.</param>
        /// <param name="offset">the 0-indexed offset for the request. Default value goes to 0. Use this parameter for pagination.</param>
        /// <returns>List of all posts that matching the query in a category</returns>
        public async Task<PostsList> GetCategoryPostList(string site, string category, PostType type, PostStatus status, int? number = null, int? offset = null)
        {
            PostsList post_list = new PostsList();

            var response = await getCategoryPosts(site, category, type, status, number, offset);

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

                    //getting attachments as List but handled as object to keep deserializing of posts possible
                    if (item.attachements != null)
                    {
                        var attachments_obj = item.attachements;
                        item.attachements = PostAttachments.GetList(attachments_obj);
                    }

                    //getting metadata as List but handled as object to keep deserializing of posts possible
                    if (item.metadata != null)
                    {
                        var metadata_obj = item.metadata;
                        item.metadata = PostMetaData.GetList(metadata_obj);
                    }
                }
            }
            else
            {
                throw new NullReferenceException("response is empty");
            }

            return post_list;
        }


        #endregion







    }
}
