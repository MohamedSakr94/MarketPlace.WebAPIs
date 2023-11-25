using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL
{
    public class ProductsRepo : GenericRepo<Products>, IProductsRepo
    {
        private readonly MarketContext options;

        public ProductsRepo(MarketContext options) : base(options)
        {
            this.options = options;
        }
        public Products GetByName(string name)
        {
            Products? product = options.Set<Products>()
                .Include(p => p.Products_Categories)
                .ThenInclude(pc => pc.Category)
                .AsNoTracking()
                .FirstOrDefault(p => p.Name == name);
            if (product == null) return null;
            return product;
        }

        public List<Products> GetByPriceRange(decimal from, decimal to)
        {
            List<Products> products = options.Set<Products>()
                .AsNoTracking()
                .Where(p => p.Price >= from && p.Price <= to).ToList();
            if (products == null) return null;
            return products;
        }

        public List<Products> GetAllWithDetails()
        {
            return options.Set<Products>()
                .Include(p => p.Products_Categories)
                .ThenInclude(pc => pc.Category)
                .AsNoTracking()
                .ToList();
        }

        public int GetCount()
        {
            return options.Set<Products>().Count();
        }



        #region unused code
        //public Products? GetByIdWithDetails(int id)
        //{
        //    return options.Set<Products>()
        //        .Include(p => p.Categories)
        //        .AsNoTracking()
        //        .FirstOrDefault(p => p.Id == id);
        //}
        #endregion
    }
}
