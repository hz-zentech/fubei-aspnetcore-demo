using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Common
{
    internal class AppJsonSerializeSettings
    {
        public static readonly JsonSerializerSettings IgnoreNullvalueHandling = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
    }
}