using System.ComponentModel.DataAnnotations;

namespace MarketPlace.BL
{
    public class ProductsAddDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<Products_CategoriesReadDTO> Products_Categories { get; set; } = new HashSet<Products_CategoriesReadDTO>();
    }
}
