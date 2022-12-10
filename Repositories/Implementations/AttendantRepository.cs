using SMS_MVCAPP.Context;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;

namespace SMS_MVCAPP.Repositories.Implementations
{
    public class AttendantRepository : IAttendantRepository
    {
        private readonly ApplicationContext _context;
        public AttendantRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Attendant CreateAttendant(Attendant attendant)
        {
            _context.attendants.Add(attendant);
            _context.SaveChanges();
            return attendant;
        }

        public void DeleteAttendant(Attendant attendant)
        {
            _context.attendants.Remove(attendant);
            _context.SaveChanges();
        }

        public IList<Attendant> GetAllAttendant()
        {
            var attendant = _context.attendants.ToList();
            return attendant;
        }

        public Attendant GetAttendantByEmail(string Email)
        {
            var attendant = _context.attendants.SingleOrDefault(x => x.Email == Email);
            return attendant;
        }

        public Attendant GetAttendantByStaffId(string staffId)
        {
            var attendant = _context.attendants.Find(staffId);
            return attendant;
        }

        public Attendant LoginAttendant(Attendant attendant)
        {
            attendant = _context.attendants.SingleOrDefault(x => x.StaffId == attendant.StaffId && x.Password == attendant.Password);
            return attendant;
        }


        public Attendant UpdateAttendant(Attendant attendant)
        {
            _context.attendants.Update(attendant);
            _context.SaveChanges();
            return attendant;
        }

        public Attendant UpdateAttendantPassword(Attendant attendant)
        {
            _context.attendants.Update(attendant);
            _context.SaveChanges();
            return attendant;
        }
    }
}
