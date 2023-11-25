namespace MarketPlace.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketContext context;

        public IProductsRepo ProductsRepo { get; }
        public ICategoriesRepo CategoriesRepo { get; }
        public IProducts_CategoriesRepo Products_CategoriesRepo { get; }
        public IUserRepo UserRepo { get; }
        public ICartItemRepo CartItemRepo { get; }


        #region Constructor
        public UnitOfWork(MarketContext context,
            IProductsRepo productsRepo,
            ICategoriesRepo categoriesRepo,
            IProducts_CategoriesRepo productCategoriesRepo,
            IUserRepo UserRepo,
            ICartItemRepo CartItemRepo)
        {
            this.context = context;

            this.ProductsRepo = productsRepo;
            this.CategoriesRepo = categoriesRepo;
            this.Products_CategoriesRepo = productCategoriesRepo;
            this.UserRepo = UserRepo;
            this.CartItemRepo = CartItemRepo;
        }
        #endregion

        public int SaveChanges()
        {
            return context.SaveChanges();

        }
    }
}
