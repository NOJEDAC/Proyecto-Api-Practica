namespace Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        TEntity Get(long id);
        void SaveOrUpdate(TEntity entity);
        void Delete(TEntity entity);
    }
}
