using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Models.Result
{
    public class H5PayData
    {
        [JsonProperty("prepay_id")]
        public string PrepayId { get; set; }

        [JsonProperty("order_sn")]
        public string OrderSn { get; set; }

        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }
    }
}