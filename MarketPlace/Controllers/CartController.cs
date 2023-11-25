using MarketPlace.BL;
using MarketPlace.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartItemsManager CartItemsManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly MarketContext options;
        public CartController(ICartItemsManager cartItemsManager, IUnitOfWork unitOfWork, MarketContext options)
        {
            CartItemsManager = cartItemsManager;
            this.unitOfWork = unitOfWork;
            this.options = options;
        }
        [HttpPost]
        [Authorize]
        [Route("AddToCart")]
        public ActionResult AddToCart(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();
            var _product = options.Set<Products>()
                .FirstOrDefault(p => p.Id == id);
            if (_product != null)
            {
                var _cartItem = options.Set<CartItem>()
                                .FirstOrDefault(c => c.User_Id == userId);
                if (_cartItem == null)
                {
                    CartItem cartItem = new()
                    {
                        Product_Id = id,
                        User_Id = userId,
                        Product = unitOfWork.ProductsRepo.GetById(id),
                        Price = unitOfWork.ProductsRepo.GetById(id).Price,
                        Quantity = 1
                    };
                    unitOfWork.CartItemRepo.Add(cartItem);
                }
                else
                {
                    _cartItem.Quantity++;
                }
                unitOfWork.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            else return NotFound();
        }
        [HttpGet]
        [Route("ItemsInCart")]
        public ActionResult<List<CartItem>> GetAllItemsInCart()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();
            var cartItems = options.CartItems.Where(c => c.User_Id == userId).ToList();
            if (cartItems == null) return NotFound();
            return cartItems;
        }
        [HttpDelete]
        [Route("RemoveItemFromCart")]
        public ActionResult RemoveItemFromCart(int id)
        {
            var cartItem = options.CartItems.FirstOrDefault(c => c.Product_Id == id);
            if (cartItem == null) return NotFound();
            options.CartItems.Remove(cartItem);
            return NoContent();
        }

    }
}