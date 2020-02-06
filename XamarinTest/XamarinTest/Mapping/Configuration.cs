using AutoMapper;

namespace XamarinTest.Mapping {
    public class Configuration {
        public static MapperConfiguration Create() {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile(new ApiModelsMapping());
            });
        }
    }
}
