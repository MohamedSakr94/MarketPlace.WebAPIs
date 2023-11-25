namespace MarketPlace.BL
{
    public class User_CartItemsReadDetailsDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public ICollection<ReadCartItemsDTO> CartItems { get; set; } = new HashSet<ReadCartItemsDTO>();
    }
}
