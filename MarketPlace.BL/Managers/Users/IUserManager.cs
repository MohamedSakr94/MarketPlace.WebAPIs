
namespace MarketPlace.BL
{
    public interface IUserManager
    {
        UserReadDTO Add(RegisterDTO UserToAdd);
        UserReadDetailsDTO GetByEmailAndPassword(LoginDTO LoginUser);
        UserReadDTO GetByEmail(string email);
        UserReadDetailsDTO GetByIdWithDetails(string id);
    }
}
