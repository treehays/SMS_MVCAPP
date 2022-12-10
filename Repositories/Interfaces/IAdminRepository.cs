using SMS_MVCAPP.Models.Entities;

namespace SMS_MVCAPP.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Admin CreateAdmin(Admin admin);
        Admin LoginAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
        Admin GetAdminByStaffId(string staffId);
        Admin GetAdminByEmail(string Email);
        IList<Admin> GetAllAdmin();
        Admin UpdateAdmin(Admin admin);
        Admin UpdateAdminPassword(Admin admin);
        //Admin Login(string staffId, string pin);
    }
}
