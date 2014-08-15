using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressUniversal.Models;

namespace WordPressUniversal.Utils
{

    /// <summary>
    /// converts a post's meta data into a List<MetaData>
    /// </summary>
    class PostMetaData
    {
        public static List<MetaData> GetList(object metadata)
        {
            List<MetaData> metadataList = new List<MetaData>();

            //make sure the list is emtpy on every new post
            metadataList.Clear();

            //avoid NullReferenceExcpetion as the object can be null on certain post objects
            if (metadata != null)
            {
                //if there is no metadata, parsing into a JObject is not possible
                if (!metadata.ToString().Contains("false"))
                {
                    //deserializing meta data list
                    metadataList = JsonConvert.DeserializeObject<List<MetaData>>(metadata.ToString());
                }
                else
                {
                    metadataList = null;
                }

            }

            return metadataList;
        }
    }
}
