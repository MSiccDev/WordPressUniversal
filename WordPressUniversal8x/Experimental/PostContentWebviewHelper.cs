using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordPressUniversal.Models;

namespace WordPressUniversal.Experimental
{
    /// <summary>
    /// this helper is considered a starting point that captures most standard scenarios.
    /// It uses an easy css string to style the WebView accordingly to the design of your app.
    /// Please note that this feature is experimental and subject to change.
    /// </summary>
    public class PostContentWebviewHelper
    {
        
        /// <summary>
        /// this should hold the post content string
        /// </summary>
        public string html_base_string { get; set; }

        /// <summary>
        /// a list of galleries in post content
        /// </summary>
        public static List<string> galleriesInPostContent;

        /// <summary>
        /// a list of image urls in a gallery
        /// </summary>
        public static List<string> imagesInGallery;

        /// <summary>
        /// the base css string for mobile devices
        /// </summary>
        public static string css_mobile_string = "<STYLE type=\"text/css\">body{background:%root_bg%;margin-left:20px; margin-right:20px;margin-bottom:20px;}p{font-family:'Segoe UI';color:%base_fg%;text-align:justify;padding-right:20px}h1{font-family:'Segoe UI';color:%header_fg%;}h2{font-family:'Segoe UI';color:%header_fg%;}h3{font-family:'Segoe UI';color:%header_fg%;}h4{font-family:'Segoe UI';color:%header_fg%;}pre{background-color:%code_bg%;color:%code_fg%;}blockquote{font-family:'Segoe UI';font-style:italic;}a:link{font-family:'Segoe UI';color:%link_fg%;text-decoration:underline}li{font-family:'Segoe UI';color:%base_fg%;font-size:310%;list-style-type:square;list-style-position:outside;padding-right:20px;padding-left:20px;}img{image-rendering:optimizeSpeed; margin-left: 10%; margin-right: 10%; width: 80%; height: auto;}</STYLE>";

        /// <summary>
        /// the base css string for big screen devices
        /// </summary>
        public static string css_bigscreen_string = "<STYLE type=\"text/css\">body{background:%root_bg%; height:90%; column-width: 400px; column-gap: 20px; overflow-x: auto; overflow-y: hidden; padding-bottom:20px; padding-left:20px;}p{font-family:'Segoe UI';color: %base_fg%;text-align: justify; font-size: 150%; padding-right: 20px;}h1{font-family:'Segoe UI';color: %header_fg%; break-before: column;font-size: 150%;}h2{font-family:'Segoe UI';color: %header_fg%;break-before: column;font-size: 150%;}h3{font-family:'Segoe UI';color: %header_fg%;break-before: column;font-size: 150%;}h4{font-family:'Segoe UI';color: %header_fg%;break-before: column;font-size: 150%;}blockquote{font-family:'Segoe UI';font-style:italic;font-size: 150%;}pre{background-color: %code_bg%; color: %code_fg%;break-before: column;font-size: 150%;}a:link{font-family:'Segoe UI';color:%link_fg%;}li{font-family: 'Segoe UI';color: %base_fg%;list-style-type: square;list-style-position: outside;padding-right: 20px: padding-left: 20px;font-size: 150%;}img{height:auto;image-rendering:optimizeSpeed;margin-left: 10%; margin-right: 10%; width: 70%; height: auto; }iframe{margin-left: 10%; margin-right: 10%; width: 70%; height: auto;}</STYLE>";

        /// <summary>
        /// script for changing the scroll direction from vertical to horizontal on big screen devices
        /// </summary>
        public static string scroll_horizontal_script = "<script type='text/javascript'>document.documentElement.style.msScrollTranslation = 'vertical-to-horizontal';</script>";


        /// <summary>
        /// gets the navigation string for the Webview including the css string that styles the content
        /// </summary>
        /// <param name="css_string">the base css string. if null, default goes to mobile css</param>
        /// <param name="background_color">the content's background color (pass a color as string or a RGB code (with leading #))</param>
        /// <param name="foreground_color">the content's foreground color (pass a color as string or a RGB code (with leading #))</param>
        /// <param name="link_color">foreground color for links (pass a color as string or a RGB code (with leading #))</param>
        /// <param name="header_foreground_color">foreground color for headers (pass a color as string or a RGB code (with leading #))</param>
        /// <param name="code_background_color">background color for code content (pass a color as string or a RGB code (with leading #))</param>
        /// <param name="code_foreground_color">foreground color for code content (pass a color as string or a RGB code (with leading #))</param>
        /// <returns>navigation string for the Webview including the css string that styles the content/returns>
        public static string NavigationString(string content, string css_string = null, HandleGallery gallery = HandleGallery.ignore,  string background_color = null, string foreground_color = null, string link_color = null, string header_foreground_color = null, string code_background_color = null, string code_foreground_color = null)
        {
            string navigation_string = string.Empty;

            //decide gallery handling
            switch (gallery)
            {
                case HandleGallery.remove:
                    content = RemoveGalleryItemStrings(content);
                    break;

                case HandleGallery.replace:
                    content = ReplaceGalleryItemStrings(content);
                    break;

                case HandleGallery.ignore:
                    break;
            }         
           
            if (css_string == null) { css_string = css_mobile_string; } 
            if (background_color == null) { background_color = "white"; }
            if (foreground_color == null) { foreground_color = "black"; }
            if (link_color == null) { link_color = "blue"; }
            if (header_foreground_color == null) { header_foreground_color = "black"; }
            if (code_background_color == null) { code_background_color = "white"; }
            if (code_foreground_color == null) { code_foreground_color = "black"; }

            css_string = css_string
                .Replace("%root_bg%", background_color)
                .Replace("%base_fg%", foreground_color)
                .Replace("%link_fg%", link_color)
                .Replace("%header_fg%", header_foreground_color)
                .Replace("%code_bg%", code_background_color)
                .Replace("%code_fg%", code_foreground_color);

#if WINDOWS_PHONE_APP
            navigation_string = css_string + content;
#else
            navigation_string = scroll_horizontal_script + css_string + content;
#endif

            return navigation_string;
        }

        public enum HandleGallery
        {
            remove = 0,

            replace = 1,

            ignore = 2
        }


        #region internal methods
        /// <summary>
        /// removes the html part that holds the gallery
        /// </summary>
        /// <param name="content"></param>
        /// <returns>content string without gallery</returns>
        private static string RemoveGalleryItemStrings(string content)
        {
            string content_removed_galleries = content;

            galleriesInPostContent = new List<string>();

            const string pattern = @"<div data-carousel-extra=(.*?)</div></div></div></div>";

            var matches = Regex.Matches(content_removed_galleries, pattern);
            var sortedMatches = matches.Cast<Match>().OrderByDescending(x => x.Index);

            foreach (var match in sortedMatches)
            {
                galleriesInPostContent.Add(match.Value);
                content_removed_galleries = content_removed_galleries.Remove(match.Index, match.Length);
            }

            return content_removed_galleries;
        }

        /// <summary>
        /// replaces the html part that holds the gallery with image items
        /// </summary>
        /// <param name="content"></param>
        /// <returns>content string with images elements instead of the gallery</returns>
        private static string ReplaceGalleryItemStrings(string content)
        {
            string content_replaced_galleries = content;

            galleriesInPostContent = new List<string>();

            const string gallery_pattern = @"<div data-carousel-extra=(.*?)</div></div></div></div>";

            
            var gallery_matches = Regex.Matches(content_replaced_galleries, gallery_pattern);
            var gallery_sortedMatches = gallery_matches.Cast<Match>().OrderByDescending(x => x.Index);

            foreach(var match in gallery_sortedMatches)
            {
                galleriesInPostContent.Add(match.Value);

                var replacement = ImagesInGalleryReplacement(match.Value);
                content_replaced_galleries = content_replaced_galleries.Remove(match.Index, match.Length).Insert(match.Index, replacement);
            }

            return content_replaced_galleries;
        }

        /// <summary>
        /// generates the replacement string for image galleries and fills List<string></string> imagesInGallery
        /// </summary>
        /// <param name="galleryHTMLString"></param>
        /// <returns>replacement string for image gallery</returns>
        private static string ImagesInGalleryReplacement(string galleryHTMLString)
        {
            string imgs_string = string.Empty;

            imagesInGallery = new List<string>();

            const string img_pattern = "data-orig-file=\"(.*?)\"";
            string img_element = "<p><img src=\"{0}\"/></p>";

            var img_matches = Regex.Matches(galleryHTMLString, img_pattern);
            var sorted_img_matches = img_matches.Cast<Match>().OrderByDescending(x => x.Index);

            foreach (var img_match in sorted_img_matches)
            {
                var img_element_string = string.Format(img_element, img_match.Value.Substring(16, img_match.Value.Length -17));

                imagesInGallery.Add(img_element_string);
                imgs_string += img_element_string;
            }

            return imgs_string;
        }

        #endregion

    }
}
