using SMS_MVCAPP.Enums;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Services.Implementations
{
    public class AdminService : IUserService
    {
        private readonly IUserRepository _adminRepository;
        public AdminService(IUserRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public User CreateUser(User user)
        {
            user.RegisteredDate = DateTime.Now.ToShortDateString();
            user.UserRole = (int)UserRole.Admin;
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            var r1 = new Random().Next(25);
            var r2 = new Random().Next(25);
            user.StaffId = $"AA{alphabet[r1]}{alphabet[r2]}" + new Random().Next(1100000);
            _adminRepository.CreateUser(user);
            return user;
        }

        public void DeleteUser(User user)
        {
            var admin = _adminRepository.GetUserByStaffId(user.StaffId);
            _adminRepository.DeleteUser(admin);
        }

        public IList<User> GetAllUser()
        {
            var listOfAdmin = _adminRepository.GetAllUser();
            return listOfAdmin;
        }

        public User GetUserByEmail(string Email)
        {
            var admin = _adminRepository.GetUserByEmail(Email);
            return admin;
        }

        public User GetUserByStaffId(string staffId)
        {
            var admin = _adminRepository.GetUserByEmail(staffId);
            return admin;
        }

        public User LoginUser(User user)
        {
            var admin = _adminRepository.LoginUser(user);
            return admin;
        }

        public User UpdateUser(User user)
        {
            var admin = _adminRepository.GetUserByStaffId(user.StaffId);
            admin.FirstName = user.FirstName;
            admin.LastName = user.LastName;
            admin.HomeAddress = user.HomeAddress;
            admin.PhoneNumber = user.PhoneNumber;
            _adminRepository.UpdateUser(user);
            return admin;
        }

        public User UpdateUserPassword(User user)
        {
            var admin = _adminRepository.GetUserByStaffId(user.StaffId);
            admin.Password = user.Password;
            _adminRepository.UpdateUserPassword(user);
            return admin;
        }
    }
}
