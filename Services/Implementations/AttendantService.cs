using SMS_MVCAPP.Enums;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Services.Implementations
{
	public class AttendantService : IAttendantService
	{
		private readonly IAttendantRepository _attendantRepository;
		public AttendantService(IAttendantRepository attendantRepository)
		{
			_attendantRepository = attendantRepository;
		}


		
		public Attendant CreateAttendant(Attendant attendant)
		{
			attendant.RegisteredDate = DateTime.Now.ToShortDateString();
			attendant.UserRole = (int)UserRole.Attendant;
			var alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
			var r1 = new Random().Next(25);
			var r2 = new Random().Next(25);
			attendant.StaffId = $"AA{alphabet[r1]}{alphabet[r2]}" + new Random().Next(1100000);
			_attendantRepository.CreateAttendant(attendant);
			return attendant;
		}

		
		public void DeleteAttendant(Attendant attendant)
		{
			attendant = _attendantRepository.GetAttendantByStaffId(attendant.StaffId);
			_attendantRepository.DeleteAttendant(attendant);
		}

		
		public IList<Attendant> GetAllAttendant()
		{
			//var listOfAttendant = _attendantRepository.GetAllAttendant();
			var listOfAttendant = _attendantRepository.GetAllAttendant().Where(x => x.UserRole == (int)UserRole.Attendant).Select(x => x).ToList();
			return listOfAttendant;
		}


		
		public Attendant GetAttendantByEmail(string Email)
		{
			var attendant = _attendantRepository.GetAttendantByEmail(Email);
			return attendant;
		}

		
		public Attendant GetAttendantByStaffId(string staffId)
		{
			var attendant = _attendantRepository.GetAttendantByStaffId(staffId);
			return attendant;
		}

		public Attendant LoginAttendant(Attendant attendant)
		{
			attendant = _attendantRepository.LoginAttendant(attendant);
			return attendant;
		}

		
		public Attendant UpdateAttendant(Attendant attendant)
		{
			var attendants = _attendantRepository.GetAttendantByStaffId(attendant.StaffId);
			attendants.FirstName = attendant.FirstName ?? attendants.FirstName;
			attendants.LastName = attendant.LastName ?? attendants.LastName;
			attendants.HomeAddress = attendant.HomeAddress ?? attendants.HomeAddress;
			//attendant.PhoneNumber = attendant.PhoneNumber ?? attendant.PhoneNumber;
			_attendantRepository.UpdateAttendant(attendants);
			return attendants;
		}

		
		public Attendant UpdateAttendantPassword(Attendant attendant)
		{
			var attendants = _attendantRepository.GetAttendantByStaffId(attendant.StaffId);
			attendants.Password = attendant.Password ?? attendants.Password;
			_attendantRepository.UpdateAttendantPassword(attendants);
			return attendants;
		}

	}
}
