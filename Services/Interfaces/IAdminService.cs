using SMS_MVCAPP.Models.Entities;

namespace SMS_MVCAPP.Services.Interfaces
{
    public interface IAdminService
    {
        Admin CreateAdmin(Admin admin);
        Admin LoginAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
        //void DeleteAdminByEmail(Admin admin);
        Admin GetAdminByStaffId(string staffId);
        Admin GetAdminByEmail(string email);
        IList<Admin> GetAllAdmin();
        Admin UpdateAdmin(Admin admin);
        Admin UpdateAdminPassword(Admin admin);
    }
}
