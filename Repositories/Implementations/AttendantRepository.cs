using SMS_MVCAPP.Context;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;

namespace SMS_MVCAPP.Repositories.Implementations
{
	public class AttendantRepository : IUserRepository
	{
		private readonly ApplicationContext _context;
		public AttendantRepository(ApplicationContext context)
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

		public List<User> GetAllUser()
		{
			var attendant = _context.users.ToList();
			return attendant;
		}

		public User GetUserByEmail(string Email)
		{
			var attendant = _context.users.SingleOrDefault(x => x.Email == Email);
			return attendant;
		}

		public User GetUserByStaffId(string staffId)
		{
			var attendant = _context.users.Find(staffId);
			return attendant;
		}

		public User LoginUser(User user)
		{
			var attendant = _context.users.SingleOrDefault(x => x.StaffId == user.StaffId && x.Password == user.Password);
			return attendant;
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
