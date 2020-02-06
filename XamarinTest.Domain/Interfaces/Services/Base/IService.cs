using System;
using System.Collections.Generic;

namespace XamarinTest.Domain.Interfaces {
    public interface IService<T> where T : class {
        void Create(T entity);
        T GetById(Guid id);
        ICollection<T> GetAll();
        void Delete(T entity);
        void Delete(Guid id);
        void Update(T entity);
    }
}
