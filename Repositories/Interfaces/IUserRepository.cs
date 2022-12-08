using SMS_MVCAPP.Models.Entities;

namespace SMS_MVCAPP.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        User LoginUser(User user);
        void DeleteUser(User user);
        User GetUserByStaffId(string staffId);
        User GetUserByEmail(string Email);
        IList<User> GetAllUser();
        User UpdateUser(User user);
        User UpdateUserPassword(User user);
        //User Login(string staffId, string pin);
    }
}
