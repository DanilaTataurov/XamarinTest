using System;
using System.Threading.Tasks;
using SQLite;
using XamarinTest.Data.Interfaces;

namespace XamarinTest.Data {
    public class Provider : IProvider {
        private readonly SQLiteAsyncConnection _asyncConnection;

        public Provider(SQLiteAsyncConnection asyncConnection) {
            _asyncConnection = asyncConnection;
        }

        public Task RunInTransaction(Action<IUnitOfWork> transaction) =>
            _asyncConnection.RunInTransactionAsync(connection => transaction.Invoke(new UnitOfWork(connection)));

        public async Task<T> RunInTransaction<T>(Func<IUnitOfWork, T> transaction) {
            T result = default;
            await _asyncConnection.RunInTransactionAsync(connection =>
                result = transaction.Invoke(new UnitOfWork(connection)));
            return result;
        }
    }
}
