using FubeiDemoMvcApplication.Common;
using FubeiDemoMvcApplication.Config;
using FubeiDemoMvcApplication.Models.Parameter;
using FubeiDemoMvcApplication.Models.Parameter.Biz;
using FubeiDemoMvcApplication.Models.Result;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FubeiDemoMvcApplication.Services.Impl
{
    public class FubeiSignatureServiceImpl : IFubeiSignatureService
    {
        private readonly ApplicationConfiguration _applicationConfiguration;
        
        public FubeiSignatureServiceImpl(IOptions<ApplicationConfiguration> options)
        {
            _applicationConfiguration = options.Value;
        }
        
        /// <summary>
        /// 生成付呗请求参数(带签名)
        /// </summary>
        /// <param name="bizParam">业务数据</param>
        /// <returns></returns>
        public FubeiRequestParam GenerateFubeiRequestParam(FubeiBizParam bizParam)
        {
            var requestParam = new FubeiRequestParam
            {
                AppId = _applicationConfiguration.AppId,
                AppSecret =  _applicationConfiguration.AppSecret,
                BizContent = JsonConvert.SerializeObject(bizParam, Formatting.Indented, AppJsonSerializeSettings.IgnoreNullvalueHandling),
                Nonce = RandomStringUtil.RandomAlphanumeric(32),
                Method = bizParam.Method
            };
            // 对请求参数进行签名
            FubeiSignatureUtil.DoSign(ref requestParam);
            return requestParam;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="result"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public bool VerifyFubeiNotification(FubeiApiCommonResult<string> result, string sign)
        {
            return FubeiSignatureUtil.Verify(result, _applicationConfiguration.AppSecret, sign);
        }
    }
}