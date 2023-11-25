namespace MarketPlace.BL
{
    public interface IProductsManager
    {
        void Add(ProductsAddDTO productToAdd);
        List<ProductsReadDTO> GetAll();
        ProductsReadDetailsDTO? GetByName(string name);
        List<ProductsReadDTO> GetByPriceRange(decimal from, decimal to);
        List<ProductsReadDetailsDTO> GetAllWithDetails();
        //ProductsReadDTO? GetById(int id);
        //ProductsReadDetailsDTO? GetDetailsById(int id);
        bool Delete(int id);
        int GetCount();
    }
}
