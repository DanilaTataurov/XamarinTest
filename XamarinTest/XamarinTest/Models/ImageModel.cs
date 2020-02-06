using Xamarin.Forms;

namespace XamarinTest.Models {
    public class ImageModel {
        public byte[] Bytes { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ImageSource ImageSource { get; set; }
    }
}
