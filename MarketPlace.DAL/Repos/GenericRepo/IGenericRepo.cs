namespace MarketPlace.DAL
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity? GetById(int id);
        void Add(TEntity TEntity);
        void Delete(int id);

    }
}
