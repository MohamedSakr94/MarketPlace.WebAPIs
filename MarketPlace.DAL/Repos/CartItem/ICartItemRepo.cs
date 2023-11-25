namespace MarketPlace.DAL
{
    public interface ICartItemRepo : IGenericRepo<CartItem>
    {
        CartItem? GetByproductId(int id);
    }
}
