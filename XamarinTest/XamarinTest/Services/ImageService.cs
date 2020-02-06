using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using XamarinTest.ApiModels.Models;
using XamarinTest.Helpers;
using XamarinTest.Services.Interfaces;
using XamarinTest.Services.Models;

namespace XamarinTest.Services {
    public class ImageService : IImageService {
        private readonly IMapper _mapper;
        private readonly IApiService _apiService;

        public ImageService(IMapper mapper, IApiService apiService) {
            _mapper = mapper;
            _apiService = apiService;
        }

        public async Task<ServiceResult> SaveAsync(byte[] image, string latitude, string longitude) {
            var response = await _apiService.DoPostFileAsync(UrlHelper.baseUrl + UrlHelper.SaveImage, image, new {
                latitude = latitude,
                longitude = longitude
            });
            if (response.IsSuccess) {
                return ServiceResult.Ok();
            }
            return ServiceResult.Fail(response.Error);
        }

        public async Task<List<ImageApiModel>> ListAsync() {
            IEnumerable<ImageApiModel> images = await _apiService.DoGetFilesAsync();
            List<ImageApiModel> list = images.ToList();
            return list;
        }
    }
}
