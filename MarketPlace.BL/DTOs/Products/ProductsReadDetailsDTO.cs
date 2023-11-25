namespace MarketPlace.BL
{
    public class ProductsReadDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<CategoriesReadDTO> Categories { get; set; } = new HashSet<CategoriesReadDTO>();
    }
}
