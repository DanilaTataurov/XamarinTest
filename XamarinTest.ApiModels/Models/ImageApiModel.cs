using System;
using Newtonsoft.Json;

namespace XamarinTest.ApiModels.Models {
    public class ImageApiModel {
        [JsonProperty("i")]
        public Guid Id { get; set; }
        [JsonProperty("b")]
        public byte[] ImageBytes { get; set; }
        [JsonProperty("n")]
        public string Name { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("u")]
        public Guid UserId { get; set; }
    }
}
