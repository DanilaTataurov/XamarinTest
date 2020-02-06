using System.Collections.Generic;
using SQLite;
using XamarinTest.Data.Interfaces;

namespace XamarinTest.Data {
    class UnitOfWork : IUnitOfWork {
        private readonly SQLiteConnection _connection;
        private readonly IDictionary<string, IRepository> _repositories;

        public UnitOfWork(SQLiteConnection connection) {
            _connection = connection;
            _repositories = new SortedDictionary<string, IRepository>();
        }

        public IRepository<T> GetRepository<T>() where T : class, new() {
            var type = typeof(T).FullName;
            if (!_repositories.ContainsKey(type)) {
                _repositories.Add(type, new Repository<T>(_connection));
            }
            return (IRepository<T>) _repositories[type];
        }
    }
}
