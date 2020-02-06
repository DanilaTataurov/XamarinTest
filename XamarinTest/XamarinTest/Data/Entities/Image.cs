using System;
using SQLite;

namespace XamarinTest.Data.Entities {
    public class Image {
        [PrimaryKey]
        public Guid Id { get; set; }
        public byte[] Bytes { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
