using System;
using System.Threading.Tasks;
using FubeiDemoMvcApplication.Common;
using FubeiDemoMvcApplication.Config;
using FubeiDemoMvcApplication.Models.Parameter.Biz;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Services.Impl
{
    public class FubeiApiRequestServiceImpl : IFubeiApiRequestService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IFubeiSignatureService _fubeiSignatureService;
        private readonly ILogger _logger;
        private readonly ApplicationConfiguration _applicationConfiguration;
        
        public FubeiApiRequestServiceImpl(IServiceProvider serviceProvider, IOptions<ApplicationConfiguration> applicationConfiguration)
        {
            _serviceProvider = serviceProvider;
            _fubeiSignatureService = serviceProvider.GetService<IFubeiSignatureService>();
            _logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(GetType());
            _applicationConfiguration = applicationConfiguration.Value;
        }
        
        public async Task<string> SendPostRequestAsync(FubeiBizParam param)
        {
            var requestParam = _fubeiSignatureService.GenerateFubeiRequestParam(param);
            var url = _applicationConfiguration.Api;
            return await HttpUtil.PostRequest(url, requestParam);
        }

        public async Task<T> SendPostRequestAsync<T>(FubeiBizParam param)
        {
            var requestParam = _fubeiSignatureService.GenerateFubeiRequestParam(param);
            var url = _applicationConfiguration.Api;
            var json = await HttpUtil.PostRequest(url, requestParam);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}