using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FubeiDemoMvcApplication.Models.Parameter;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Common
{
    /// <summary>
    /// Http请求类封装
    /// 请仔细阅读以下文章，确保能够正确使用HttpClient：
    /// YOU'RE USING HTTPCLIENT WRONG AND IT IS DESTABILIZING YOUR SOFTWARE | https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
    /// .NET HttpClient，存在缺陷让开发人员沮丧 | http://www.oschina.net/news/77036/httpclient
    /// </summary>
    public class HttpUtil
    {
        /// <summary>
        /// 包含HttpClient的ThreadLocal对象
        /// </summary>
        private static readonly ThreadLocal<HttpClient> _tlHttpClient = new ThreadLocal<HttpClient>(() =>
        {
            var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
            return client;
        });

        private IHostingEnvironment _hostingEnvironment;
        
        public HttpUtil(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public static async Task<string> PostRequest(string url, JsonRequestParam jsonRequestParam)
        {
            var httpClient = _tlHttpClient.Value;

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(JsonConvert.SerializeObject(jsonRequestParam), Encoding.UTF8, "application/json");
            
            var httpResponseMessage = await httpClient.PostAsync(url, content);
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}