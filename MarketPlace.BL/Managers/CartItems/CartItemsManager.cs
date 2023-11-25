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

        //public void AddToCart(int id)
        //{
        //    var cartItem = unitOfWork.CartItemRepo.GetByproductId(id);
        //    if (cartItem == null)
        //    {
        //        cartItem = new CartItem
        //        {
        //            Product_Id = id,
        //            Product = unitOfWork.ProductsRepo.GetById(id),
        //            Price = unitOfWork.ProductsRepo.GetById(id).Price,
        //            Quantity = 1
        //        };
        //        unitOfWork.CartItemRepo.Add(cartItem);
        //    }
        //    else
        //    {
        //        cartItem.Quantity++;
        //    }
        //    unitOfWork.SaveChanges();
        //}
        public List<CategoriesReadDTO> GetAll()
        {
            List<Categories> Categories = unitOfWork.CategoriesRepo.GetAll();
            return Categories.Select(x => new CategoriesReadDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
        public bool Delete(int id)
        {
            Categories? category = unitOfWork.CategoriesRepo.GetById(id);
            if (category == null)
            { return false; }
            unitOfWork.CategoriesRepo.Delete(id);
            unitOfWork.SaveChanges();
            return true;
        }

    }
}
