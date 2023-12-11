namespace MarketPlace.DAL
{
    public interface IUserRepo : IGenericRepo<User>
    {
        User? GetByIdWithDetails(string id);
        User? GetByEmailAndPassword(string email, string hashedPassword);
        public User? GetByEmail(string email);
    }
}
