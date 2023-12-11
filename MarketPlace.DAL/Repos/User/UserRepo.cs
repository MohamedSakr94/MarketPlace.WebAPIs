using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly MarketContext options;

        public UserRepo(MarketContext options) : base(options)
        {
            this.options = options;
        }

        public User? GetByIdWithDetails(string id)
        {
            return options.Set<User>()
                .Include(u => u.CartItems)
                .ThenInclude(u => u.Product)
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == id.ToString());
        }


        public User? GetByEmailAndPassword(string email, string hashedPassword)
        {
            return options.Set<User>()
                .Include(u => u.CartItems)
                .ThenInclude(u => u.Product)
                .FirstOrDefault(
                    u => u.Email == email
                    && u.PasswordHash == hashedPassword);

        }
        public User? GetByEmail(string email)
        {
            return options.Set<User>()
                .AsNoTracking()
                .FirstOrDefault(
                    u => u.Email == email);
        }
    }
}
