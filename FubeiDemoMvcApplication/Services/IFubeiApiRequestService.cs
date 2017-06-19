using System.Threading.Tasks;
using FubeiDemoMvcApplication.Models.Parameter.Biz;

namespace FubeiDemoMvcApplication.Services
{
    public interface IFubeiApiRequestService
    {
        Task<T> SendPostRequestAsync<T>(FubeiBizParam param);
    }
}