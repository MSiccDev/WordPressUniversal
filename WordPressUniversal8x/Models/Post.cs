using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressUniversal.Models;

namespace WordPressUniversal.Models
{
    /// <summary>
    /// base model that contains data of a WordPress post
    /// </summary>
    public class Post
    {
        /// <summary>
        /// The post ID.
        /// </summary>
        [JsonProperty("ID")]
        public int id { get; set; }

        /// <summary>
        /// The site ID.
        /// </summary>
        [JsonProperty("site_ID")]
        public int site_id {get; set;}

        /// <summary>
        /// The author of the post.
        /// </summary>
        [JsonProperty("author")]
        public Author author {get; set;}

        /// <summary>
        /// The post's creation time.
        /// </summary>
        [JsonProperty("date")]
        public string date {get; set;}

        /// <summary>
        /// The post's most recent update time.
        /// </summary>
        [JsonProperty("modified")]
        public string modified_date {get; set;}

        /// <summary>
        /// The post's title as plain text string
        /// </summary>
        [JsonProperty("title")]
        public string title {get; set;}


        /// <summary>
        /// The full permalink URL to the post.
        /// </summary>
        [JsonProperty("URL")]
        public string url {get; set;}

        /// <summary>
        /// The wp.me short URL.
        /// </summary>
        [JsonProperty("short_URL")]
        public string short_url {get; set;}

        /// <summary>
        /// The post's content as HTML formatted string
        /// </summary>
        [JsonProperty("content")]
        public string content {get; set;}

        /// <summary>
        /// The post's exceprt as HTML formatted string
        /// </summary>
        [JsonProperty("excerpt")]
        public string excerpt {get; set;}

        /// <summary>
        /// The name (slug) for the post, used in URLs.
        /// </summary>
        [JsonProperty("slug")]
        public string slug {get; set;}

        /// <summary>
        /// The GUID for the post.
        /// </summary>
        [JsonProperty("guid")]
        public string guid {get; set;}

        /// <summary>
        /// The post's status.
        /// publish:The post is published.
        /// draft:The post is saved as a draft.
        /// pending:The post is pending editorial approval.
        /// future:The post is scheduled for future publishing.
        /// trash:The post is in the trash.
        /// </summary>
        [JsonProperty("status")]
        public string status {get; set;}

        /// <summary>
        /// The post's stickyness state
        /// </summary>
        [JsonProperty("sticky")]
        public bool is_sticky {get; set;}

        /// <summary>
        /// The plaintext password protecting the post, or, more likely, the empty string if the post is not password protected.
        /// </summary>
        [JsonProperty("password")]
        public string password {get; set;}

        /// <summary>
        /// A reference to the post's parent, if it has one
        /// </summary>
        [JsonProperty("parent")]
        public object parent {get; set;}

        /// <summary>
        /// The post's type. Post types besides post, page and revision need to be whitelisted using the 'rest_api_allowed_post_types' filter on WordPress.
        /// </summary>
        [JsonProperty("type")]
        public string type {get; set;}

        /// <summary>
        /// Is the post open for comments?
        /// </summary>
        [JsonProperty("comments_open")]
        public bool comments_allowed {get; set;}

        /// <summary>
        /// Is the post open for pingbacks, trackbacks?
        /// </summary>
        [JsonProperty("pings_open")]
        public bool pings_allowed {get; set;}

        /// <summary>
        /// Is the post open to likes?
        /// </summary>
        [JsonProperty("likes_enabled")]
        public bool likes_enabled {get; set;}

        /// <summary>
        /// Should sharing buttons show on this post?
        /// </summary>
        [JsonProperty("sharing_enabled")]
        public bool sharingbuttons_visible {get; set;}

        /// <summary>
        /// Should a Google+ account be associated with this post?
        /// </summary>
        [JsonProperty("gplusauthorship_enabled")]
        public bool gplususer_associated {get; set;}

        /// <summary>
        /// The number of comments for this post.
        /// </summary>
        [JsonProperty("comment_count")]
        public int comment_count {get; set;}

        /// <summary>
        /// The number of likes for this post.
        /// </summary>
        [JsonProperty("like_count")]
        public int likes_count {get; set;}

        /// <summary>
        /// Does the current user like this post?
        /// </summary>
        [JsonProperty("i_like")]
        public bool liked {get; set;}

        /// <summary>
        /// Did the current user reblog this post?
        /// </summary>
        [JsonProperty("is_reblogged")]
        public bool reblogged {get; set;}

        /// <summary>
        /// Is the current user following this blog?
        /// </summary>
        [JsonProperty("is_following")]
        public bool user_isfollowing {get; set;}

        /// <summary>
        /// A unique WordPress.com-wide representation of a post.
        /// </summary>
        [JsonProperty("global_ID")]
        public string wordpress_globalid {get; set;}

        /// <summary>
        /// The URL to the featured image for this post if it has one.
        /// </summary>
        [JsonProperty("featured_image")]
        public string featured_image_url {get; set;}

        /// <summary>
        /// The attachment object for the featured image if it has one.
        /// </summary>
        [JsonProperty("thumbnail")]
        public object featured_image_object {get; set;}

        /// <summary>
        /// The post's format. Supported formats:
        /// - standard: Standard
        /// - aside: Aside
        /// - chat: Chat
        /// - gallery: Gallery
        /// - link: Link
        /// - image: Image
        /// - quote: Quote
        /// - status: Status
        /// - video: Video
        /// - audio: Audio
        /// </summary>
        [JsonProperty("format")]
        public string format {get; set;}

        /// <summary>
        /// The post's geo.
        /// </summary>
        [JsonProperty("geo")]
        public object geo {get; set;}

        /// <summary>
        /// List of Twitter and Facebook URLs published by this post.
        /// </summary>
        [JsonProperty("publicize_URLs")]
        public List<object> publicize_urls {get; set;}

        /// <summary>
        /// Tags (keyed by tag name) applied to the post.
        /// </summary>
        [JsonProperty("tags")]
        public object tags {get; set;}

        /// <summary>
        /// Categories (keyed by category name) applied to the post.
        /// </summary>
        [JsonProperty("categories")]
        public object categories {get; set;}

        /// <summary>
        /// The Post attachments (keyed by internal attachment ID).
        /// </summary>
        [JsonProperty("attachments")]
        public object attachments {get; set;}

        /// <summary>
        /// Array of post metadata keys and values. 
        /// All unprotected meta keys are available by default for read requests. 
        /// Both unprotected and protected meta keys are available for authenticated requests with access. 
        /// Protected meta keys can be made available with the rest_api_allowed_public_metadata filter on WordPress.
        /// </summary>
        [JsonProperty("metadata")]
        public object metadata {get; set;}

        /// <summary>
        /// API result meta data
        /// </summary>
        [JsonProperty("meta")]
        public PostMeta meta { get; set; }

    }
}
