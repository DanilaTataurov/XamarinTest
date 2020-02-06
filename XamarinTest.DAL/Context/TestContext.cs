using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using XamarinTest.DAL.DbConfigs;
using XamarinTest.Domain.Entities;
using XamarinTest.Domain.Identity;

namespace XamarinTest.DAL.Context {
    public class TestContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim> {
        public DbSet<Image> Images { get; set; }

        public TestContext() : base("DefaultConnection") { }

        public static TestContext Create() {
            return new TestContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new ImageConfig());
            modelBuilder.Configurations.Add(new UserRoleConfig());
            modelBuilder.Configurations.Add(new UserLoginConfig());
        }
    }
}
