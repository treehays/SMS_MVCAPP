using SMS_MVCAPP.Enums;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Services.Implementations
{
	public class AttendantService : IUserService
	{
		private readonly IUserRepository _attendantRepository;
		public AttendantService(IUserRepository attendantRepository)
		{
			_attendantRepository = attendantRepository;
		}


		
		public User CreateUser(User user)
		{
			user.RegisteredDate = DateTime.Now.ToShortDateString();
			user.UserRole = (int)UserRole.Attendant;
			var alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
			var r1 = new Random().Next(25);
			var r2 = new Random().Next(25);
			user.StaffId = $"AA{alphabet[r1]}{alphabet[r2]}" + new Random().Next(1100000);
			_attendantRepository.CreateUser(user);
			return user;
		}

		
		public void DeleteUser(User user)
		{
			var attendant = _attendantRepository.GetUserByStaffId(user.StaffId);
			_attendantRepository.DeleteUser(attendant);
		}

		
		public IList<User> GetAllUser()
		{
			//var listOfAttendant = _attendantRepository.GetAllUser();
			var listOfAttendant = _attendantRepository.GetAllUser().Where(x => x.UserRole == (int)UserRole.Attendant).Select(x => x).ToList();
			return listOfAttendant;
		}


		
		public User GetUserByEmail(string Email)
		{
			var attendant = _attendantRepository.GetUserByEmail(Email);
			return attendant;
		}

		
		public User GetUserByStaffId(string staffId)
		{
			var attendant = _attendantRepository.GetUserByStaffId(staffId);
			return attendant;
		}

		public User LoginUser(User user)
		{
			var attendant = _attendantRepository.LoginUser(user);
			return attendant;
		}

		
		public User UpdateUser(User user)
		{
			var attendant = _attendantRepository.GetUserByStaffId(user.StaffId);
			attendant.FirstName = user.FirstName ?? attendant.FirstName;
			attendant.LastName = user.LastName ?? attendant.LastName;
			attendant.HomeAddress = user.HomeAddress ?? attendant.HomeAddress;
			//attendant.PhoneNumber = user.PhoneNumber ?? attendant.PhoneNumber;
			_attendantRepository.UpdateUser(attendant);
			return attendant;
		}

		
		public User UpdateUserPassword(User user)
		{
			var attendant = _attendantRepository.GetUserByStaffId(user.StaffId);
			attendant.Password = user.Password ?? attendant.Password;
			_attendantRepository.UpdateUserPassword(attendant);
			return attendant;
		}

	}
}
