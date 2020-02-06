using System.Threading.Tasks;

namespace XamarinTest.Domain.Interfaces {
    public interface IUnitOfWork {
        IRepository<T> GetRepository<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();
        bool AutoDetectChanges { get; set; }
    }
}
