using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webCrawler
{
    public class SendHttpRequest
    {
        private readonly string url;

        public SendHttpRequest(string url)
        {
            if (url == null) throw new ArgumentNullException("url");
            this.url = url;
        }

        public string Url { get { return url; }}


        public async Task<string> FetchHtmlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }


    }
}
