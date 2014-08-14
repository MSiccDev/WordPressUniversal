using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressUniversal.Utils
{
    public class PostCategories
    {
        /// <summary>
        /// parses the keys from object categories of a post 
        /// </summary>
        /// <param name="categories">object categories from Post</param>
        /// <returns>comma separated string that contains all post categories</returns>
        public static string GetString(object categories)
        {
            string cat_string = string.Empty;
            int cat_obj_count = 0;

            //avoid NullReferenceExcpetion as the object can be null on certain objects
            if (categories != null)
            {
                //parsing as object to avoid dependence on JSON.Net in app project
                JObject cat_obj = JObject.Parse(categories.ToString());

                foreach (var item in cat_obj)
                {
                    //generating comparison count and bool to detect the last item
                    //to avoid adding ',' on it
                    cat_obj_count++;
                    bool isLast = cat_obj_count == cat_obj.Count;

                    cat_string = string.Concat(cat_string, item.Key.ToString());
                    cat_string += isLast ? string.Empty : ", ";
                }
            }

            return cat_string;
        }
    }
}
