using System;
using System.Collections.Generic;
using XamarinTest.Domain.Entities;

namespace XamarinTest.Domain.Interfaces.Services {
    public interface IImageService : IService<Image> {
        void Save(Guid userId, byte[] image, double latitude, double longitude);
        IEnumerable<Image> ListByUserId(Guid id);
    }
}
