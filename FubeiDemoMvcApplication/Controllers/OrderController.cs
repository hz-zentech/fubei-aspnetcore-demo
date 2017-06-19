using System;
using System.Threading.Tasks;
using FubeiDemoMvcApplication.Models.Parameter.Biz;
using FubeiDemoMvcApplication.Models.Result;
using FubeiDemoMvcApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FubeiDemoMvcApplication.Controllers
{
    public class OrderController : FubeiApiBaseController
    {
        private readonly IOrderService _orderService;
        public OrderController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider) : base(loggerFactory, serviceProvider)
        {
            _orderService = serviceProvider.GetService<IOrderService>();
        }

        [HttpPost, ActionName("h5pay")]
        public async Task<FubeiApiCommonResult<H5PayData>> H5Pay(
            [FromForm(Name = "open_id")] string openId, 
            [FromForm(Name = "sub_open_id")] string subOpenId, 
            [FromForm(Name = "total_fee")] decimal? totalFee, 
            [FromForm(Name = "store_id")] int? storeId,
            [FromForm(Name = "cashier_id")] int? cashierId)
        {
            return await PostRequestAsync<H5PayData>(new FubeiH5PayBizParam
            {
                OpenId = openId,
                SubOpenId = subOpenId,
                CashierId = cashierId,
                MerchantOrderSn = _orderService.GenerateOrderId(),
                StoreId = storeId,
                TotalFee = totalFee
            });
        }        
    }
}