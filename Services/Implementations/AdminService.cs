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

        
        //done
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
        
        //done
        public void DeleteUser(User user)
        {
            var admin = _adminRepository.GetUserByStaffId(user.StaffId);
            _adminRepository.DeleteUser(admin);
        }     
        
        //done
        public IList<User> GetAllUser()
        {
            //var listOfAdmin = _adminRepository.GetAllUser();
            //var listOfAdmin = _adminRepository.GetAllUser().Select(x => x.UserRole == (int)UserRole.Admin).ToList();
            var listOfAdmin = _adminRepository.GetAllUser().Where(x => x.UserRole == (int)UserRole.Admin).Select(x => x).ToList();
            return listOfAdmin;
        }

       
        //done
        public User GetUserByEmail(string Email)
        {
            var admin = _adminRepository.GetUserByEmail(Email);
            return admin;
        }

        //done
        public User GetUserByStaffId(string staffId)
        {
            var admin = _adminRepository.GetUserByStaffId(staffId);
            return admin;
        }

        //done
        public User LoginUser(User user)
        {
            var admin = _adminRepository.LoginUser(user);
            return admin;
        }

        //done
        public User UpdateUser(User user)
        {
            var admin = _adminRepository.GetUserByStaffId(user.StaffId);
            admin.FirstName = user.FirstName ?? admin.FirstName;
            admin.LastName = user.LastName ?? admin.LastName ;
            admin.HomeAddress = user.HomeAddress ?? admin.HomeAddress;
            //admin.PhoneNumber = user.PhoneNumber ?? admin.PhoneNumber;
            _adminRepository.UpdateUser(admin);
            return admin;
        }

        //done
        public User UpdateUserPassword(User user)
        {
            var admin = _adminRepository.GetUserByStaffId(user.StaffId);
            admin.Password = user.Password ?? admin.Password;
            _adminRepository.UpdateUserPassword(admin);
            return admin;
        }
    }
}
