using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Models.Parameter.Biz
{
    public class FubeiBizParam : IBaseModel
    {
        protected FubeiBizParam(string method) {
            Method = method;
        }

        [JsonIgnore]
        public string Method { get; }
    }
}