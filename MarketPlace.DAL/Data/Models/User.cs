
using Microsoft.AspNetCore.Identity;

namespace MarketPlace.DAL
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        //public string UserName { get; set; } = string.Empty;
        //public string Email { get; set; } = string.Empty;
        //public string Password { get; set; } = string.Empty;


        #region Nav Properties
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
        #endregion
    }
}
