namespace MarketPlace.BL
{
    public class CategoriesReadDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ProductsReadDTO> Products { get; set; } = new HashSet<ProductsReadDTO>();
    }
}
