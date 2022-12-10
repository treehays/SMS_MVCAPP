using SMS_MVCAPP.Models.Entities;

namespace SMS_MVCAPP.Repositories.Interfaces
{
    public interface IAttendantRepository
    {
        Attendant CreateAttendant(Attendant attendant);
        Attendant LoginAttendant(Attendant attendant);
        void DeleteAttendant(Attendant attendant);
        Attendant GetAttendantByStaffId(string staffId);
        Attendant GetAttendantByEmail(string Email);
        IList<Attendant> GetAllAttendant();
        Attendant UpdateAttendant(Attendant attendant);
        Attendant UpdateAttendantPassword(Attendant attendant);
        //Attendant Login(string staffId, string pin);
    }
}
