using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinTest.ApiModels.Models;
using XamarinTest.Services.Models;

namespace XamarinTest.Services.Interfaces {
    public interface IImageService {
        Task<ServiceResult> SaveAsync(byte[] image, string latitude, string longitude);
        Task<List<ImageApiModel>> ListAsync();
    }
}
