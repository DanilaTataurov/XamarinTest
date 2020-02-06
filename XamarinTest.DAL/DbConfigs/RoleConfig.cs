using System.Data.Entity.ModelConfiguration;
using XamarinTest.Domain.Entities;

namespace XamarinTest.DAL.DbConfigs {
    public class RoleConfig : EntityTypeConfiguration<Role> {
        public RoleConfig() {
            HasKey(r => r.Id);
        }
    }
}
