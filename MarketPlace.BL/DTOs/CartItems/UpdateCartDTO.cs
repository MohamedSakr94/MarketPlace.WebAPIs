namespace MarketPlace.BL
{
    public class UpdateCartDTO
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public string User_Id { get; set; } = String.Empty;
    }
}
