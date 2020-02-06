using System;
using XamarinTest.Domain.Entities.Base;

namespace XamarinTest.Domain.Entities {
    public class Image : BaseEntity {
        public byte[] ImageBytes { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
