using System;
using Microsoft.AspNet.Identity.EntityFramework;
using XamarinTest.Domain.Identity;

namespace XamarinTest.Domain.Entities {
    public class Role : IdentityRole<Guid, UserRole> {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
