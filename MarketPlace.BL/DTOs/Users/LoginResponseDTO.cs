namespace MarketPlace.BL
{
    public class LoginResponseDTO
    {
        public UserReadDetailsDTO? UserReadDetails { get; set; } = null!;
        public string Token { get; set; } = string.Empty;
    }
}
