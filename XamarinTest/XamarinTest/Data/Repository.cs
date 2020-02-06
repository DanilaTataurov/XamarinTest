using System.Collections.Generic;
using System.Linq;
using SQLite;
using XamarinTest.Data.Interfaces;

namespace XamarinTest.Data {
    public class Repository<T> : IRepository<T> where T : new() {
        private SQLiteConnection _db;
        private bool _isInitialized = false;

        public Repository(SQLiteConnection db) {
            _db = db;
            if (!_isInitialized) {
                _db.CreateTable<T>();
            }
        }

        public virtual IEnumerable<T> All() =>
            _db.Table<T>();

        public virtual T GetById(object id) =>
            _db.Find<T>(id);

        public virtual int Insert(T entity) =>
            _db.Insert(entity);

        public virtual int Insert(IEnumerable<T> entities) =>
            _db.InsertAll(entities, !_db.IsInTransaction);

        public virtual int Update(T entity) =>
            _db.Update(entity);

        public virtual int Update(IEnumerable<T> entities) =>
            _db.UpdateAll(entities, !_db.IsInTransaction);

        public virtual int UpdateOrInsert(T entity) {
            var result = _db.Update(entity);
            return result == 0 ? _db.Insert(entity) : result;
        }

        public virtual int UpdateOrInsert(IEnumerable<T> entities) =>
            entities?.Sum(entity => UpdateOrInsert(entity)) ?? 0;

        public virtual int InsertOrReplace(T entity) =>
            _db.InsertOrReplace(entity);

        public virtual int InsertOrReplace(IEnumerable<T> entities) =>
            entities?.Sum(entity => InsertOrReplace(entity)) ?? 0;

        public virtual int Delete(T entity) =>
            _db.Delete(entity);

        public virtual int Delete(object id) =>
            _db.Delete<T>(id);

        public virtual int DeleteAll() =>
            _db.DeleteAll<T>();

        public virtual int Delete(IEnumerable<T> entities) =>
            entities?.Sum(entity => Delete(entity)) ?? 0;
    }
}