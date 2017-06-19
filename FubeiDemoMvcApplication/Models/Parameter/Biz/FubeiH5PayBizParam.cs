using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Models.Parameter.Biz
{
    public class FubeiH5PayBizParam : FubeiBizParam
    {
        public FubeiH5PayBizParam() : base("openapi.payment.order.h5pay") {}
        
        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn;

        [JsonProperty("open_id")]
        public string OpenId;

        [JsonProperty("sub_open_id")]
        public string SubOpenId;

        [JsonProperty("total_fee")]
        public decimal? TotalFee;

        [JsonProperty("store_id")]
        public int? StoreId;

        [JsonProperty("cashier_id")]
        public int? CashierId;
    }
}