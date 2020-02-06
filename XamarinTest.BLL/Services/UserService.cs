using System;
using System.Linq;
using XamarinTest.BLL.Services.Base;
using XamarinTest.Domain.Entities;
using XamarinTest.Domain.Interfaces;
using XamarinTest.Domain.Interfaces.Services;

namespace XamarinTest.BLL.Services {
    public class UserService : BaseService<User>, IUserService {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public User GetById(Guid id) {
            return _unitOfWork.GetRepository<User>().Where(c => c.Id == id).FirstOrDefault();
        }

        public User GetByEmail(string email) {
            return _unitOfWork.GetRepository<User>().Where(c => c.Email == email).FirstOrDefault();
        }
    }
}
