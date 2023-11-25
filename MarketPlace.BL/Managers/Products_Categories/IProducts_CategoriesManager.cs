namespace MarketPlace.BL
{
    public interface IProducts_CategoriesManager
    {
        void Add(Products_CategoriesAddDTO Products_CategoriesToAdd);
        List<Products_CategoriesReadDTO> GetAll();
    }
}
