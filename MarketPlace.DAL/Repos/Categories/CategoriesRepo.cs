using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL
{
    public class CategoriesRepo : GenericRepo<Categories>, ICategoriesRepo
    {
        private readonly MarketContext options;

        public CategoriesRepo(MarketContext options) : base(options)
        {
            this.options = options;
        }

        public Categories GetProductsByCategory(string CategoryName)
        {
            Categories? Category = options.Set<Categories>()
                .Include(c => c.Products_Categories)
                .ThenInclude(pc => pc.Product)
                .AsNoTracking()
                .FirstOrDefault(p => p.Name == CategoryName);
            if (Category == null) return null;
            return Category;
        }
    }
}
