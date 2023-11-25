//using MarketPlace.DAL;

//namespace MarketPlace.BL
//{
//    public class UserManager : IUserManager
//    {
//        private readonly IUnitOfWork unitOfWork;
//        #region Constructor
//        public UserManager(IUnitOfWork unitOfWork)
//        {
//            this.unitOfWork = unitOfWork;
//        }

//        public void Add(RegisterDTO UserToAdd)
//        {
//            User user = new()
//            {
//                Username = UserToAdd.UserName,
//                Email = UserToAdd.Email,
//                Password = UserToAdd.Password,
//            };
//            unitOfWork.UserRepo.Add(user);
//            unitOfWork.SaveChanges();
//        }

//        public User_CartItemsReadDetailsDTO ReadUserCartWithDetails(int id)
//        {
//            User? _user = unitOfWork.UserRepo.GetByIdWithDetails(id);
//            if (_user == null)
//            { return null; }
//            User_CartItemsReadDetailsDTO cart = new()
//            {
//                Id = _user.Id,
//                Username = _user.Username,
//                CartItems = _user.CartItems.Select(c => new ReadCartItemsDTO
//                {
//                    Id = c.Id,
//                    Product_Id = c.Product_Id,
//                    Quantity = c.Quantity,
//                    Price = c.Price
//                }).ToList()
//            };
//            return cart;
//        }
//        #endregion

//    }
//}
