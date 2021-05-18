namespace Business.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Save(T entity);

        void Remove(T entity);

        int LastId();
    }
}