using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Models.Result
{
    /// <summary>
    /// 返回的通用结果
    /// </summary>
    /// <typeparam name="TData">Data实体类型</typeparam>
    public class FubeiApiCommonResult<TData> : IBaseModel 
    {
        [JsonProperty("result_code")]
        [FromForm(Name = "result_code")]
        public string ResultCode { get; set; }
        
        [JsonProperty("result_message")]
        [FromForm(Name = "result_message")]
        public string ResultMessage { get; set; }
        
        [JsonProperty("data")]
        [FromForm(Name = "data")]
        public TData Data { get; set; }
    }
}