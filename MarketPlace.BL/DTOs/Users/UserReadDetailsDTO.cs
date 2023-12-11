namespace MarketPlace.BL
{
    public class UserReadDetailsDTO
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<ReadCartItemsWithDetailsDTO> CartItems { get; set; } = new HashSet<ReadCartItemsWithDetailsDTO>();
    }
}
