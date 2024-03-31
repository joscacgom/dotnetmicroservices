using dotnetmicro.Web.Models;
namespace dotnetmicro.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDTO);
    }
}