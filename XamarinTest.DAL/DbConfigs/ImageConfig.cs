using System.Data.Entity.ModelConfiguration;
using XamarinTest.Domain.Entities;

namespace XamarinTest.DAL.DbConfigs {
    public class ImageConfig : EntityTypeConfiguration<Image> {
        public ImageConfig() {
            HasKey(t => t.Id);
        }
    }
}
