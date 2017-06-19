using System;
using System.Threading.Tasks;
using FubeiDemoMvcApplication.Models.Parameter.Biz;
using FubeiDemoMvcApplication.Models.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FubeiDemoMvcApplication.Controllers
{
    public class AuthController : FubeiApiBaseController
    {
        public AuthController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider) : base(loggerFactory, serviceProvider)
        {
        }

        [HttpGet, ActionName("authorize")]
        public async Task<FubeiApiCommonResult<AuthUrlData>> Auth([FromQuery(Name = "returnUrl")]string url)
        {
            return await PostRequestAsync<AuthUrlData>(new FubeiAuthorizeParam
            {
                Url = url
            });
        }
    }
}