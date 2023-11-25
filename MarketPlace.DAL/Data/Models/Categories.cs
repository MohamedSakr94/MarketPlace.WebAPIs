using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DAL
{
    public class Categories
    {
        #region Attributes
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        #endregion

        #region Nav.Properties
        public ICollection<Products_Categories> Products_Categories { get; set; } = new HashSet<Products_Categories>();
        //public ICollection<Products> Products { get; set; } = new HashSet<Products>();
        #endregion
    }
}
