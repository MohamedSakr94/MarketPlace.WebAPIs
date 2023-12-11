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

        public CartItem? GetByIdWithDetails(int id)
        {
            return options.Set<CartItem>()
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefault(c => c.Id == id);
        }
        public CartItem? CheckCartItem(string User_id, int Product_id)
        {
            return options.Set<CartItem>().FirstOrDefault(c => c.User_Id == User_id && c.Product_Id == Product_id);

        }
    }
}
