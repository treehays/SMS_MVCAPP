using SMS_MVCAPP.Models.Entities;

namespace SMS_MVCAPP.Services.Interfaces
{
    public interface IAttendantService
    {
        Attendant CreateAttendant(Attendant attendant);
        Attendant LoginAttendant(Attendant attendant);
        void DeleteAttendant(Attendant attendant);
        //void DeleteAttendantByEmail(Attendant attendant);
        Attendant GetAttendantByStaffId(string staffId);
        Attendant GetAttendantByEmail(string email);
        IList<Attendant> GetAllAttendant();
        Attendant UpdateAttendant(Attendant attendant);
        Attendant UpdateAttendantPassword(Attendant attendant);
    }
}
