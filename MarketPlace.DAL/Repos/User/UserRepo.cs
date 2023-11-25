namespace MarketPlace.DAL
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly MarketContext options;

        public UserRepo(MarketContext options) : base(options)
        {
            this.options = options;
        }
        //public User? GetByIdWithDetails(int id)
        //{
        //    return options.Set<User>()
        //        .Include(p => p.CartItems)
        //        .AsNoTracking()
        //        .FirstOrDefault(p => p.Id == id);
        //}
    }
}
