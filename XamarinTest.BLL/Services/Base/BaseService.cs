using System;
using System.Collections.Generic;
using XamarinTest.Domain.Interfaces;

namespace XamarinTest.BLL.Services.Base {
    public class BaseService<T> : IService<T> where T : class {
        public readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public void Create(T entity) {
            _unitOfWork.GetRepository<T>().Add(entity);
            _unitOfWork.Commit();
        }

        public T GetById(Guid id) {
            return _unitOfWork.GetRepository<T>().FindById(id);
        }

        public void Update(T entity) {
            _unitOfWork.GetRepository<T>().Update(entity);
            _unitOfWork.Commit();
        }

        public ICollection<T> GetAll() {
            return new List<T>(_unitOfWork.GetRepository<T>().All());
        }

        public void Delete(T entity) {
            _unitOfWork.GetRepository<T>().Remove(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id) {
            _unitOfWork.GetRepository<T>().Remove(id);
            _unitOfWork.Commit();
        }
    }
}
