using System.Collections.Generic;

namespace XamarinTest.Data.Interfaces {
    public interface IRepository { }

    public interface IRepository<T> : IRepository where T : new() {
        IEnumerable<T> All();
        T GetById(object id);
        int Insert(T entity);
        int Insert(IEnumerable<T> entities);
        int Update(T entity);
        int Update(IEnumerable<T> entities);
        int UpdateOrInsert(T entity);
        int UpdateOrInsert(IEnumerable<T> entities);
        int InsertOrReplace(T entity);
        int InsertOrReplace(IEnumerable<T> entities);
        int Delete(T entity);
        int Delete(object id);
        int DeleteAll();
        int Delete(IEnumerable<T> entities);
    }
}
