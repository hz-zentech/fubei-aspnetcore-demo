using System;
using FubeiDemoMvcApplication.Models.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Controllers
{
    public class NotifyController : FubeiApiBaseController
    {
        public NotifyController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider) : base(loggerFactory, serviceProvider)
        {
        }
        
        [HttpPost]
        [Route("/notify")]
        public string Index([FromForm] FubeiApiCommonResult<string> notify, [FromForm(Name = "sign")] string sign)
        {
            var valid = FubeiSignatureService.VerifyFubeiNotification(notify, sign);
            if (valid)
            {
                Logger.LogInformation("Notification [VALID] => {0}, Sign: {1}", JsonConvert.SerializeObject(notify), sign);
            }
            else
            {
                Logger.LogWarning("Notification [INVALID] => {0}, Sign: {1}", JsonConvert.SerializeObject(notify), sign);
            }
            return "SUCCESS";
        }
    }
}