using FubeiDemoMvcApplication.Models.Result;
using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Models.Parameter
{
    public class FubeiNotificationParam : FubeiApiCommonResult<string>
    {
        public FubeiNotificationParam(FubeiApiCommonResult<string> data)
        {
            Data = data.Data;
            ResultCode = data.ResultCode;
            ResultMessage = data.ResultMessage;
        }
        
        [JsonIgnore]
        public string AppSecret { get; set; }
    }
}