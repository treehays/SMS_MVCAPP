using SMS_MVCAPP.Models.Entities;

namespace SMS_MVCAPP.Services.Interfaces
{
    public interface IUserService
    {
        User CreateUser(User user);
        User LoginUser(User user);
        void DeleteUser(User user);
        //void DeleteUserByEmail(User user);
        User GetUserByStaffId(string staffId);
        User GetUserByEmail(string Email);
        IList<User> GetAllUser();
        User UpdateUser(User user);
        User UpdateUserPassword(User user);
    }
}
