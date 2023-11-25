namespace MarketPlace.DAL
{
    public class Products_CategoriesRepo : GenericRepo<Products_Categories>, IProducts_CategoriesRepo
    {
        private readonly MarketContext options;

        public Products_CategoriesRepo(MarketContext options) : base(options)
        {
            this.options = options;
        }
    }
}
