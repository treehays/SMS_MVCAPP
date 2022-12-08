using SMS_MVCAPP.Context;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;

namespace SMS_MVCAPP.Repositories.Implementations
{
    public class AdminRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(User user)
        {
            _context.users.Remove(user);
            _context.SaveChanges();
        }

        public IList<User> GetAllUser()
        {
            var users = _context.users.ToList();
            return users;
        }

        public User GetUserByEmail(string Email)
        {
            var user = _context.users.SingleOrDefault(x => x.Email == Email);
            return user;
        }

        public User GetUserByStaffId(string staffId)
        {
            var user = _context.users.Find(staffId);
            return user;
        }

        public User LoginUser(User user)
        {
            var users = _context.users.SingleOrDefault(x => x.StaffId == user.StaffId && x.Password == user.Password);
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUserPassword(User user)
        {
            _context.users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
