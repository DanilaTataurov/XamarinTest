using System;
using System.Threading.Tasks;

namespace XamarinTest.Data.Interfaces {
    public interface IProvider {
        Task RunInTransaction(Action<IUnitOfWork> transaction);
        Task<T> RunInTransaction<T>(Func<IUnitOfWork, T> transaction);
    }
}
