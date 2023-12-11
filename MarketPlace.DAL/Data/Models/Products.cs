using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DAL
{
    public class Products
    {
        #region Attributes
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        #endregion

        #region Nav.Properties
        public ICollection<Products_Categories> Products_Categories { get; set; } = new HashSet<Products_Categories>();
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
        /*public ICollection<Categories> Categories { get; set; } = new HashSet<Categories>();*/
        #endregion
    }
}
