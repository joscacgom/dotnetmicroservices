using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dotnetmicro.Web.Models;
using dotnetmicro.Web.Service.IService;
using dotnetmicro.Web.Utils;
using Newtonsoft.Json;

namespace dotnetmicro.Web.Service
{
    public class BaseService : IBaseService
    {

        private readonly IHttpClientFactory _clientFactory;

        public BaseService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<ResponseDTO?> SendAsync(RequestDTO requestDTO)
        {
            try{

                HttpClient client = _clientFactory.CreateClient("WebAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestDTO.Url);
                if(requestDTO.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(requestDTO.Data),
                        Encoding.UTF8,
                        "application/json"
                    );
                }
                
                HttpResponseMessage apiResponse = new HttpResponseMessage();

                switch(requestDTO.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch(apiResponse.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        var successResponse = JsonConvert.DeserializeObject<ResponseDTO>(response);
                        return successResponse;
                    case HttpStatusCode.Unauthorized:
                        return new() { Message = "Unauthorized", IsSuccess = false };
                    case HttpStatusCode.NotFound:
                        return new() { Message = "Not found", IsSuccess = false };
                    case HttpStatusCode.BadRequest:
                    return new() { Message = "Bad request", IsSuccess = false };
                    default:
                        return new() { Message = "Error", IsSuccess = false};
                }
            } catch(Exception ex)
            {
                return new() { Message = ex.Message, IsSuccess = false };
            }

        }
    }
}