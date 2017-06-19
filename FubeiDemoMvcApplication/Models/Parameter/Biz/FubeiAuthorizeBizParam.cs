using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Models.Parameter.Biz
{
    public class FubeiAuthorizeParam : FubeiBizParam
    {
        public FubeiAuthorizeParam() : base("openapi.payment.auth.auth") {}
        
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}