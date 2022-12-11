using SMS_MVCAPP.Enums;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        
        //done
        public Admin CreateAdmin(Admin admin)
        {
            admin.RegisteredDate = DateTime.Now.ToShortDateString();
            admin.UserRole = (int)UserRole.Admin;
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            var r1 = new Random().Next(25);
            var r2 = new Random().Next(25);
            admin.StaffId = $"AA{alphabet[r1]}{alphabet[r2]}" + new Random().Next(1100000);
            _adminRepository.CreateAdmin(admin);
            return admin;
        }
        
        //done
        public void DeleteAdmin(Admin admin)
        {
            admin = _adminRepository.GetAdminByStaffId(admin.StaffId);
            _adminRepository.DeleteAdmin(admin);
        }     
        
        //done
        public IList<Admin> GetAllAdmin()
        {
            //var listOfAdmin = _adminRepository.GetAllAdmin();
            //var listOfAdmin = _adminRepository.GetAllAdmin().Select(x => x.AdminRole == (int)AdminRole.Admin).ToList();
            var listOfAdmin = _adminRepository.GetAllAdmin().Where(x => x.UserRole == (int)UserRole.Admin).Select(x => x).ToList();
            return listOfAdmin;
        }

       
        //done
        public Admin GetAdminByEmail(string email)
        {
            var admin = _adminRepository.GetAdminByEmail(email);
            return admin;
        }

        //done
        public Admin GetAdminByStaffId(string staffId)
        {
            var admin = _adminRepository.GetAdminByStaffId(staffId);
            return admin;
        }

        //done
        public Admin LoginAdmin(Admin admin)
        {
            admin = _adminRepository.LoginAdmin(admin);
            return admin;
        }

        //done
        public Admin UpdateAdmin(Admin admin)
        {
            var admins = _adminRepository.GetAdminByStaffId(admin.StaffId);
            admins.FirstName = admin.FirstName ?? admins.FirstName;
            admins.LastName = admin.LastName ?? admins.LastName ;
            admins.HomeAddress = admin.HomeAddress ?? admins.HomeAddress;
            //admins.PhoneNumber = admin.PhoneNumber ?? admin.PhoneNumber;
            _adminRepository.UpdateAdmin(admins);
            return admins;
        }

        //done
        public Admin UpdateAdminPassword(Admin admin)
        {
            var admins = _adminRepository.GetAdminByStaffId(admin.StaffId);
            admins.Password = admin.Password ?? admins.Password;
            _adminRepository.UpdateAdminPassword(admins);
            return admins;
        }
    }
}
