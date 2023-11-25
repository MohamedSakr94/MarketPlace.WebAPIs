namespace MarketPlace.BL
{
    public interface ICartItemsManager
    {
        //void AddToCart(int id);
        List<CategoriesReadDTO> GetAll();
        bool Delete(int id);
    }
}
