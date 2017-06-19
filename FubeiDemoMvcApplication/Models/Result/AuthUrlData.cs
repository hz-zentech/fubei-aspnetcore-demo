using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Models.Result
{
    public class AuthUrlData : IBaseModel
    {
        [JsonProperty("authUrl")]
        public string AuthUrl { get; set; }
    }
}