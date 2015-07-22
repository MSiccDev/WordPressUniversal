using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Utils
{
    class PostTags
    {
        /// <summary>
        /// parses the keys of the tags object of a post
        /// </summary>
        /// <param name="tags">object tags from Post</param>
        /// <returns>comma separated string that contains all post tags<</returns>
        public static string GetString(object tags)
        {
            string tag_string = string.Empty;
            int tags_count = 0;

            //avoid NullReferenceExcpetion as the object can be null on certain objects
            if (tags != null)
            {
                //parsing as object to avoid dependence on JSON.Net in app project
                JObject tag_obj = JObject.Parse(tags.ToString());

                foreach (var item in tag_obj)
                {
                    //generating comparison count and bool to detect the last item
                    //to avoid adding ',' on it
                    tags_count++;
                    bool isLast = tags_count == tag_obj.Count;

                    tag_string = string.Concat(tag_string, item.Key.ToString());
                    tag_string += isLast ? string.Empty : ", ";
                }
            }

            return tag_string;
        }
    }
}
