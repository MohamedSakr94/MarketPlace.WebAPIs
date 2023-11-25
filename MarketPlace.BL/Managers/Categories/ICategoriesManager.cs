namespace MarketPlace.BL
{
    public interface ICategoriesManager
    {
        void Add(CategoriesAddDTO categoryToAdd);
        List<CategoriesReadDTO> GetAll();
        CategoriesReadDTO GetById(int id);
        bool Delete(int id);
        CategoriesReadDetailsDTO GetProductsByCategory(string catName);
    }
}
