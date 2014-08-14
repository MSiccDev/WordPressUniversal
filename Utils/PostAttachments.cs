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
    public class PostAttachments
    {
        public static List<Attachment> GetList(object attachments)
        {
            List<Attachment> attachmentList = new List<Attachment>();

            //make sure the List<Attachment> is empty on every new post
            attachmentList.Clear();

            //avoid NullReferenceExcpetion as the object can be null on certain objects
            if (attachments != null)
            {
                //parsing as object to avoid dependence on JSON.Net in app project
                JObject attachment_obj = JObject.Parse(attachments.ToString());

                //adding attachment objects to the List<Attachment>
                foreach (var item in attachment_obj)
                {
                    //attachments have always same properties, that's why they can be deserialized
                    var att = JsonConvert.DeserializeObject<Attachment>(item.Value.ToString());
                    attachmentList.Add(att);
                }
            }

            return attachmentList;
        }

        
    }
}
