using System.Data.Entity.ModelConfiguration;
using XamarinTest.Domain.Identity;

namespace XamarinTest.DAL.DbConfigs {
    public class UserRoleConfig : EntityTypeConfiguration<UserRole> {
        public UserRoleConfig() {
            HasKey(r => new {
                r.UserId, r.RoleId
            });
        }
    }
}
