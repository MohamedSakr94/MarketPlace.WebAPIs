using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.DAL
{
    public class CartItem
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string? User_Id { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        #region Nav Properties
        public User User { get; set; } = null!;
        public Products Product { get; set; } = null!;
        #endregion
    }
}
