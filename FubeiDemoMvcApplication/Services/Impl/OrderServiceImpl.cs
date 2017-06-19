using System;
using FubeiDemoMvcApplication.Common;

namespace FubeiDemoMvcApplication.Services.Impl
{
    public class OrderServiceImpl : IOrderService
    {
        private const string Pattern = "yyyyMMddHHmmssSSS";

        public string GenerateOrderId()
        {
            return string.Format("{0}_{1}", DateTime.Now.ToString(Pattern), RandomStringUtil.RandomAlphanumeric(8));
        }
    }
}