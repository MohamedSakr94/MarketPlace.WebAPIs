using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        private readonly MarketContext context;

        #region Constructor
        public GenericRepo(MarketContext context)
        {
            this.context = context;
        }
        #endregion

        #region CRUD
        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>()
                .AsNoTracking()
                .ToList();
        }

        public TEntity? GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity TEntity)
        {
            context.Set<TEntity>().Add(TEntity);
        }

        public void Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id)!;
            context.Set<TEntity>().Remove(entity);
        }
        #endregion

    }
}
