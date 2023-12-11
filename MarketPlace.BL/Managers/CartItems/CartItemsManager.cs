using MarketPlace.DAL;

namespace MarketPlace.BL
{
    public class CartItemsManager : ICartItemsManager
    {
        private readonly IUnitOfWork unitOfWork;
        #region Constructor
        public CartItemsManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        public ReadCartItemsDTO AddCartItem(ItemAddToCartDTO itemAdded)
        {
            var _cartItem = unitOfWork.CartItemRepo.CheckCartItem(itemAdded.User_Id, itemAdded.Product_Id);
            if (_cartItem == null)
            {
                CartItem cartItem = new()
                {
                    User_Id = itemAdded.User_Id,
                    Product_Id = itemAdded.Product_Id,
                    Quantity = itemAdded.Quantity,
                };
                unitOfWork.CartItemRepo.Add(cartItem);
                unitOfWork.SaveChanges();
                ReadCartItemsDTO readCartItemsDTO = new()
                {
                    Id = cartItem.Id,
                    Product_Id = cartItem.Product_Id,
                    User_Id = cartItem.User_Id,
                    Quantity = cartItem.Quantity
                };
                return readCartItemsDTO;
            }
            else
            {
                _cartItem.Quantity++;
                unitOfWork.SaveChanges();
                ReadCartItemsDTO readCartItemsDTO = new()
                {
                    Id = _cartItem.Id,
                    Product_Id = _cartItem.Product_Id,
                    User_Id = _cartItem.User_Id,
                    Quantity = _cartItem.Quantity
                };
                return readCartItemsDTO;
            }
        }

        public ReadCartItemsDTO GetById(int id)
        {
            CartItem? dbCartItem = unitOfWork.CartItemRepo.GetById(id);
            if (dbCartItem == null) return null!;
            ReadCartItemsDTO cartItem = new()
            {
                Id = dbCartItem.Id,
                Product_Id = dbCartItem.Product_Id,
                User_Id = dbCartItem.User_Id,
                Quantity = dbCartItem.Quantity,
            };
            return cartItem;
        }

        public ReadCartItemsWithDetailsDTO GetByIdWithDetails(int id)
        {
            CartItem? dbCartItem = unitOfWork.CartItemRepo.GetByIdWithDetails(id);
            if (dbCartItem == null) return null!;
            ReadCartItemsWithDetailsDTO cartItem = new()
            {
                Id = dbCartItem.Id,
                Product_Id = dbCartItem.Product_Id,
                User_Id = dbCartItem.User_Id,
                Quantity = dbCartItem.Quantity,

                Product = new ProductsReadDTO
                {
                    Id = dbCartItem.Product_Id,
                    Name = dbCartItem.Product.Name,
                    Price = dbCartItem.Product.Price,
                }
            };
            return cartItem;
        }

        public bool DeleteById(int id)
        {
            CartItem? cartItem = unitOfWork.CartItemRepo.GetById(id);
            if (cartItem == null)
            { return false; }
            unitOfWork.CartItemRepo.Delete(id);
            unitOfWork.SaveChanges();
            return true;
        }
        public bool Delete(DeleteItemFromCartDTO itemcart)
        {
            return DeleteById(itemcart.Id);
        }

    }
}
