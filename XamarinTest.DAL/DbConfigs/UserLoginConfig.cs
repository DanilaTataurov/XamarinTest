using System.Data.Entity.ModelConfiguration;
using XamarinTest.Domain.Identity;

namespace XamarinTest.DAL.DbConfigs {
    class UserLoginConfig : EntityTypeConfiguration<UserLogin> {
        public UserLoginConfig() {
            HasKey(r => new {
                r.UserId, 
                r.LoginProvider, 
                r.ProviderKey
            });
        }
    }
}
