using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS_MVCAPP.Models.Entities
{
    public class User
    {
        [Key]
        [DisplayName("Staff Number")]
        public string StaffId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Mobile Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Registeration Date")]
        public string RegisteredDate { get; set; }
        [DisplayName("Gender")]
        public string Gender { get; set; }
        [DisplayName("Home Address")]
        public string HomeAddress { get; set; }
        [DisplayName("Guarantor Name")]
        public string GuarantorName { get; set; } 
        [DisplayName("Position")]
        public int UserRole { get; set; }
    }
}
