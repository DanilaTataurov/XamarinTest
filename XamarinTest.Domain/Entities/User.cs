using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using XamarinTest.Domain.Entities.Base;
using XamarinTest.Domain.Identity;

namespace XamarinTest.Domain.Entities {
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>, IEntity<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual IEnumerable<Image> Image { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, Guid> manager, string authenticationType) {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
