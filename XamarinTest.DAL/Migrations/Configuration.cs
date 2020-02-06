using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using XamarinTest.Domain.Entities;
using XamarinTest.Domain.Identity;

namespace XamarinTest.DAL.Migrations {
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<XamarinTest.DAL.Context.TestContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XamarinTest.DAL.Context.TestContext context) {
            var roleStore = new RoleStore<Role, Guid, UserRole>(context);
            var roleManager = new RoleManager<Role, Guid>(roleStore);

            if (!roleManager.RoleExists(Role.Admin)) {
                roleManager.Create(new Role { Id = Guid.NewGuid(), Name = Role.Admin });
            }

            if (!roleManager.RoleExists(Role.User)) {
                roleManager.Create(new Role { Id = Guid.NewGuid(), Name = Role.User });
            }

            var userStore = new UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>(context);
            var userManager = new UserManager<User, Guid>(userStore);
            var usersWithoutRoles = context.Users.Where(u => u.Roles.Count == 0).ToList();

            foreach (var user in usersWithoutRoles)
                userManager.AddToRole(user.Id, Role.Admin);
        }
    }
}
