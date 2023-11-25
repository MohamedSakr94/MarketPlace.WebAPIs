namespace MarketPlace.DAL
{
    public interface ICategoriesRepo : IGenericRepo<Categories>
    {
        Categories GetProductsByCategory(string CategoryName);
    }
}
