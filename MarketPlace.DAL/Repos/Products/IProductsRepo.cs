namespace MarketPlace.DAL
{
    public interface IProductsRepo : IGenericRepo<Products>
    {
        List<Products> GetAllWithDetails();
        //Products? GetByIdWithDetails(int id);
        Products GetByName(string name);
        List<Products> GetByPriceRange(decimal from, decimal to);
        int GetCount();

    }
}
