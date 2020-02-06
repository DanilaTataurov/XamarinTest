using System;
using System.Collections.Generic;
using System.Linq;
using XamarinTest.BLL.Services.Base;
using XamarinTest.Domain.Entities;
using XamarinTest.Domain.Interfaces;
using XamarinTest.Domain.Interfaces.Services;

namespace XamarinTest.BLL.Services {
    public class ImageService : BaseService<Image>, IImageService {
        public ImageService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void Save(Guid userId, byte[] image, double latitude, double longitude) {
            Image entity = new Image() {
                ImageBytes = image, 
                Name = DateTime.Now.ToString("s") + "_XamarinTest.jpg",
                Latitude = latitude, 
                Longitude = longitude,
                UserId = userId
            };
            _unitOfWork.GetRepository<Image>().Add(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<Image> ListByUserId(Guid id) {
            return _unitOfWork.GetRepository<Image>()
                .Where(c => c.User.Id == id)
                .OrderBy(x=>x.CreatedAt).ToList();
        }
    }
}
