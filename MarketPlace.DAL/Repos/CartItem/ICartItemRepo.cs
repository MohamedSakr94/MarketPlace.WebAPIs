namespace MarketPlace.DAL
{
    public interface ICartItemRepo : IGenericRepo<CartItem>
    {
        CartItem? GetByIdWithDetails(int id);
        CartItem? CheckCartItem(string User_id, int Product_id);
    }
}
