using AutoMapper;

namespace XamarinTest.Web.Mapping {
    public class Configuration {
        public static MapperConfiguration Create() {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile(new DataModelsMapping());
                cfg.AddProfile(new ApiModelsMapping());
            });
        }
    }
}