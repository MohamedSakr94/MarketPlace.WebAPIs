using MarketPlace.DAL;

namespace MarketPlace.BL
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork unitOfWork;
        #region Constructor
        public UserManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public UserReadDTO GetByEmail(string email)
        {
            User? dbUser = unitOfWork.UserRepo.GetByEmail(email);
            if (dbUser is null) return null!;
            UserReadDTO user = new()
            {
                Id = dbUser.Id,
                Email = dbUser.Email,
                UserName = dbUser.UserName,
            };
            return user;
        }
        public UserReadDTO Add(RegisterDTO UserToAdd)
        {
            User? dbUser = unitOfWork.UserRepo.GetByEmail(UserToAdd.Email);
            if (dbUser == null)
            {
                User user = new()
                {
                    UserName = UserToAdd.UserName,
                    Email = UserToAdd.Email,
                    PasswordHash = Helpers.HashPassword(UserToAdd.Password)
                };
                unitOfWork.UserRepo.Add(user);
                unitOfWork.SaveChanges();

                UserReadDTO userReadDTO = new()
                {
                    Id = user.Id,
                    UserName = user.Email,
                    Email = user.Email
                };
                return userReadDTO;
            }
            return null!;
        }

        public UserReadDetailsDTO GetByEmailAndPassword(LoginDTO LoginUser)
        {
            LoginUser.Password = Helpers.HashPassword(LoginUser.Password);
            User? dbUser = unitOfWork.UserRepo.GetByEmailAndPassword(LoginUser.Email, LoginUser.Password);
            if (dbUser is null) return null!;
            UserReadDetailsDTO LogedInUser = new()
            {
                Id = dbUser.Id,
                Email = dbUser.Email,
                UserName = dbUser.UserName,
                CartItems = dbUser.CartItems.Select(c => new ReadCartItemsWithDetailsDTO
                {
                    Id = c.Id,
                    Product_Id = c.Product_Id,
                    User_Id = c.User_Id!,
                    Quantity = c.Quantity,

                    Product = new ProductsReadDTO
                    {
                        Id = c.Product!.Id,
                        Name = c.Product!.Name,
                        Price = c.Product!.Price
                    }
                }).ToList()
            };
            return LogedInUser;
        }

        public UserReadDetailsDTO GetByIdWithDetails(string id)
        {
            User? dbUser = unitOfWork.UserRepo.GetByIdWithDetails(id);
            if (dbUser is null) return null!;
            if (dbUser.CartItems == null)
            {
                UserReadDetailsDTO ReadUserWithoutCartItems = new()
                {
                    Id = dbUser.Id,
                    UserName = dbUser.UserName,
                    Email = dbUser.Email,
                };
                return ReadUserWithoutCartItems;
            }
            else
            {
                UserReadDetailsDTO ReadUser = new()
                {
                    Id = dbUser.Id,
                    UserName = dbUser.UserName,
                    Email = dbUser.Email,
                    CartItems = dbUser.CartItems.Select(c => new ReadCartItemsWithDetailsDTO
                    {
                        Id = c.Id,
                        Product_Id = c.Product_Id,
                        User_Id = c.User_Id!,
                        Quantity = c.Quantity,

                        Product = new ProductsReadDTO
                        {
                            Id = c.Product!.Id,
                            Name = c.Product!.Name,
                            Price = c.Product!.Price
                        }
                    }).ToList()
                };
                return ReadUser;
            }
        }
        #endregion


    }
}
