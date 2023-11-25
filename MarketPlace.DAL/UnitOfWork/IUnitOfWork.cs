namespace MarketPlace.DAL
{
    public interface IUnitOfWork
    {
        public IProductsRepo ProductsRepo { get; }
        public ICategoriesRepo CategoriesRepo { get; }
        public IProducts_CategoriesRepo Products_CategoriesRepo { get; }
        public IUserRepo UserRepo { get; }
        public ICartItemRepo CartItemRepo { get; }


        int SaveChanges();
    }
}
