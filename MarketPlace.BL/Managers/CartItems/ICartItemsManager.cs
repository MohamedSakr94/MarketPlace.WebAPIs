namespace MarketPlace.BL
{
    public interface ICartItemsManager
    {
        ReadCartItemsDTO AddCartItem(ItemAddToCartDTO itemAdded);
        ReadCartItemsDTO GetById(int id);
        ReadCartItemsWithDetailsDTO GetByIdWithDetails(int id);
        bool DeleteById(int id);
        bool Delete(DeleteItemFromCartDTO itemcart);

    }
}
