using System.Data.Entity.ModelConfiguration;
using XamarinTest.Domain.Entities;

namespace XamarinTest.DAL.DbConfigs {
    public class UserConfig : EntityTypeConfiguration<User> {
        public UserConfig() {
            HasKey(t => t.Id);
        }
    }
}
