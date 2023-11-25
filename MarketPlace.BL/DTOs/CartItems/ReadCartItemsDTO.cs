namespace MarketPlace.BL
{
    public class ReadCartItemsDTO
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
