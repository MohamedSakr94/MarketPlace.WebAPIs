namespace MarketPlace.BL
{
    public class ReadCartItemsWithDetailsDTO
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public string User_Id { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public UserReadDetailsDTO? User { get; set; } = null!;
        public ProductsReadDTO? Product { get; set; } = null!;
    }
}
