using System;
using Microsoft.AspNet.Identity.EntityFramework;
using XamarinTest.Domain.Entities;

namespace XamarinTest.Domain.Identity {
    public class UserRole : IdentityUserRole<Guid> {
        public virtual Role Role { get; set; }
    }
}
