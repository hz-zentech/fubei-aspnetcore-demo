using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Models.Parameter
{
    public class FubeiRequestParam : JsonRequestParam
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }
        
        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("format")]
        public string Format => "json";

        [JsonProperty("sign_method")]
        public string SignMethod => "md5";
        
        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("version")]
        public string Version => "1.0";
        
        [JsonProperty("biz_content")]
        public string BizContent { get; set; }
        
        [JsonProperty("sign")]
        public string Sign { get; set; }
        
        [JsonIgnore]
        public string AppSecret { get; set; }
    }
}