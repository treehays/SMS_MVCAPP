using SMS_MVCAPP.Context;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;

namespace SMS_MVCAPP.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;
        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Admin CreateAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        public void DeleteAdmin(Admin admin)
        {
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }

        public IList<Admin> GetAllAdmin()
        {
            var admins = _context.Admins.ToList();
            return admins;
        }

        public Admin GetAdminByEmail(string email)
        {
            var admin = _context.Admins.SingleOrDefault(x => x.Email == email);
            return admin;
        }

        public Admin GetAdminByStaffId(string staffId)
        {
            var admin = _context.Admins.Find(staffId);
            return admin;
        }

        public Admin LoginAdmin(Admin admin)
        {
            admin = _context.Admins.SingleOrDefault(x => x.StaffId == admin.StaffId && x.Password == admin.Password);
            return admin;
        }


        public Admin UpdateAdmin(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return admin;
        }

        public Admin UpdateAdminPassword(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return admin;
        }
    }
}
