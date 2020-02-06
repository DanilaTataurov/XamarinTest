using System;
using Microsoft.AspNet.Identity.EntityFramework;
using XamarinTest.DAL.Context;
using XamarinTest.Domain.Entities;
using XamarinTest.Domain.Identity;

namespace XamarinTest.BLL.Identity {
    public class ApplicationUserStore : UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim> {
        public ApplicationUserStore(TestContext context) : base(context) { }
    }
}
