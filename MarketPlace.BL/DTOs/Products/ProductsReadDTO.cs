namespace MarketPlace.BL
{
    public class ProductsReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
