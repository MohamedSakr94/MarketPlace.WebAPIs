using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL
{
    public class CartItemRepo : GenericRepo<CartItem>, ICartItemRepo
    {
        private readonly MarketContext options;

        public CartItemRepo(MarketContext options) : base(options)
        {
            this.options = options;
        }

        public CartItem? GetByproductId(int id)
        {
            return options.Set<CartItem>()
                .Include(p => p.Product)
                .FirstOrDefault(c => c.Product.Id == id);
        }
    }
}
