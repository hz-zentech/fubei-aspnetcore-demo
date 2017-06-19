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
    [Route("api/[controller]/[action]")]
    public class FubeiApiBaseController : Controller
    {
        protected readonly ILogger Logger;
        protected ILoggerFactory LoggerFactory;
        protected IServiceScope ServiceScope;
        
        protected readonly IFubeiSignatureService FubeiSignatureService;
        protected readonly IFubeiApiRequestService FubeiApiRequestService;
        
        public FubeiApiBaseController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            Logger = loggerFactory.CreateLogger(GetType().FullName);
            FubeiSignatureService = serviceProvider.GetService<IFubeiSignatureService>();
            ServiceScope = serviceProvider.GetService<IServiceScope>();
            FubeiApiRequestService = serviceProvider.GetService<IFubeiApiRequestService>();
        }

        protected async Task<FubeiApiCommonResult<T>> PostRequestAsync<T>(FubeiBizParam obj) where T : new()
        {
            return await FubeiApiRequestService.SendPostRequestAsync<FubeiApiCommonResult<T>>(obj);
        }
    }
}