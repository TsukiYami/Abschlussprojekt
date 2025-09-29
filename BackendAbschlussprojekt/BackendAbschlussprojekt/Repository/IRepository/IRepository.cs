namespace BackendAbschlussprojekt.Repository.IRepository
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T? GetByID(long nID);
        long Insert(T oEntity);
        void Update(T oEntity);
        void Delete(long nID);
    }
}
