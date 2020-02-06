namespace XamarinTest.Data.Interfaces {
    public interface IUnitOfWork {
        IRepository<T> GetRepository<T>() where T : class, new();
    }
}