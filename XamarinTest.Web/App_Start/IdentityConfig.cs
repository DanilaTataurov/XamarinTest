using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using XamarinTest.BLL.Identity;
using XamarinTest.DAL.Context;
using XamarinTest.Domain.Entities;

namespace XamarinTest.Web {
    public class TestUserManager : UserManager<User, Guid> {
        public TestUserManager(IUserStore<User, Guid> store)
            : base(store) { }

        public override Task<IdentityResult> CreateAsync(User user) {
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            return base.CreateAsync(user);
        }

        public static TestUserManager Create(IdentityFactoryOptions<TestUserManager> options, IOwinContext context) {
            var manager = new TestUserManager(new ApplicationUserStore(context.Get<TestContext>()));
            manager.UserValidator = new UserValidator<User, Guid>(manager) {
                AllowOnlyAlphanumericUserNames = false, RequireUniqueEmail = true
            };
            manager.PasswordValidator = new PasswordValidator {
                RequireNonLetterOrDigit = false, RequireDigit = false, RequireLowercase = false, RequireUppercase = false
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null) {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User, Guid>(dataProtectionProvider.Create("ASP.NET Identity")) {
                    TokenLifespan = TimeSpan.FromHours(4)
                };
            }
            return manager;
        }
    }

    public class TestSignInManager : SignInManager<User, Guid> {
        public TestSignInManager(TestUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user) {
            return user.GenerateUserIdentityAsync((TestUserManager) UserManager, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public static TestSignInManager Create(IdentityFactoryOptions<TestSignInManager> options, IOwinContext context) {
            return new TestSignInManager(context.GetUserManager<TestUserManager>(), context.Authentication);
        }
    }
}
