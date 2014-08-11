using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using WordPressUniversal.Models;

namespace WordPressUniversal.Client
{
    public class WordPressClient
    {
        public async Task<string> GetJSonClient(string site, PostType type, PostStatus status, int? number = null)
        {
            if (!number.HasValue)
            {
                number = 10;
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.IfModifiedSince = DateTime.Now;

            return await client.GetStringAsync(new Uri(Endpoints.posts(site, type, status, number)));
        }







    }
}
