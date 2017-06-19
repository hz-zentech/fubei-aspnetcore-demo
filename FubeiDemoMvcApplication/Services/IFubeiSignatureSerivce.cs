using FubeiDemoMvcApplication.Models.Parameter;
using FubeiDemoMvcApplication.Models.Parameter.Biz;
using FubeiDemoMvcApplication.Models.Result;

namespace FubeiDemoMvcApplication.Services
{
    public interface IFubeiSignatureService
    {
        FubeiRequestParam GenerateFubeiRequestParam(FubeiBizParam bizParam);

        bool VerifyFubeiNotification(FubeiApiCommonResult<string> result, string sign);
    }
}