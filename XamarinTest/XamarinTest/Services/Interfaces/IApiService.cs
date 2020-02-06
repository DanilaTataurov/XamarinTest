using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinTest.ApiModels.Models;
using XamarinTest.Services.Models;

namespace XamarinTest.Services.Interfaces {
    public interface IApiService {
        Task<ApiResponse> DoRequestAsync(string method, string uri, object postParameters);
        Task<ApiResponse> DoPostFileAsync(string uri, byte[] image, object postParameters);
        Task<IEnumerable<ImageApiModel>> DoGetFilesAsync();
        Task<ApiResponse> DoLoginAsync(string username, string password);
    }
}
