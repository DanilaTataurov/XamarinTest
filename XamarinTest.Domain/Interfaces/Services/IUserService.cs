using System;
using XamarinTest.Domain.Entities;

namespace XamarinTest.Domain.Interfaces.Services {
    public interface IUserService : IService<User> {
        User GetById(Guid id);
        User GetByEmail(string email);
    }
}
