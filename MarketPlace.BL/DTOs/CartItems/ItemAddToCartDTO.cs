using MarketPlace.DAL;

namespace MarketPlace.BL
{
    public class ItemAddToCartDTO
    {
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public User User { get; set; } = null!;
    }
}
