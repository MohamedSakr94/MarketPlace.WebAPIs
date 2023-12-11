using MarketPlace.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartItemsManager CartItemsManager;
        public CartController(ICartItemsManager cartItemsManager)
        {
            CartItemsManager = cartItemsManager;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "JWT")]
        public ActionResult<ReadCartItemsDTO> AddToCart(ItemAddToCartDTO itemToBeAdded)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != itemToBeAdded.User_Id) return StatusCode(403);
            return CartItemsManager.AddCartItem(itemToBeAdded);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = "JWT")]
        public ActionResult RemoveItemFromCart([FromHeader(Name = "Authorization")][Required] string Authorization, int id)
        {
            CartItemsManager.DeleteById(id);
            return StatusCode(200);
        }

        //[HttpGet]
        //[Route("ItemsInCart")]
        //public ActionResult<List<CartItem>> GetAllItemsInCart()
        //{
        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if (userId == null) return Unauthorized();
        //    var cartItems = options.CartItems.Where(c => c.User_Id == userId).ToList();
        //    if (cartItems == null) return NotFound();
        //    return cartItems;
        //}




    }
}