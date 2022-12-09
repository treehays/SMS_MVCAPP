using Microsoft.AspNetCore.Mvc;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Services.Implementations;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Controllers
{
    public class AttendantController : Controller
    {
        private readonly IUserService _attendantService;
        public AttendantController(IUserService attendantService)
        {
            _attendantService = attendantService;
        }


        public IActionResult Index()
        {
            return View();
        }

        //Attendant Dashboard
        public IActionResult AttendantPage()
        {
            return View();
        }


        //creating attendant
        public IActionResult CreateAttendant()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAttendant(User user)
        {
            if (_attendantService.GetUserByEmail(user.Email) == null)
            {
                _attendantService.CreateUser(user);
                TempData["sucess"] = "Registrtion Sucessful.    ";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["failed"] = "Registrtion Failed";
                return View();
            }
        }

        //get all attendants

        public IActionResult GetAllAttendants()
        {
            var attendant = _attendantService.GetAllUser();
            return View(attendant);
        }

        //get a single attendant by stff id
        public IActionResult GetAttendantByStaffId(string staffId)
        {
            var attendant = _attendantService.GetUserByStaffId(staffId);
            return View(attendant);
        }

        //get a single attendant by email
        public IActionResult GetAttendantByEmail(string email)
        {
            var attendant = _attendantService.GetUserByEmail(email);
            return View(attendant);
        }


        //deleting attendant
        public IActionResult DeleteAttendant(User user)
        {
            _attendantService.DeleteUser(user);
            return RedirectToAction("GetAllAttendants");
        }

        public IActionResult DeleteAttendantConfirmPage(string staffId)
        {
            var attendant = _attendantService.GetUserByStaffId(staffId);
            return View(attendant);
        }

        //Updating User
        public IActionResult UpdateAttendant(string staffId)
        {
            var attendant = _attendantService.GetUserByStaffId(staffId);
            return View(attendant);
        }

        [HttpPost]
        public IActionResult UpdateAttendant(User user)
        {
            _attendantService.UpdateUser(user);
            return RedirectToAction(nameof(GetAllAttendants));
        }

        //Updating User password
        public IActionResult UpdateAttendantPassword(string staffId)
        {
            var attendant = _attendantService.GetUserByStaffId(staffId);
            return View(attendant);
        }

        [HttpPost]
        public IActionResult UpdateAttendantPassword(User user)
        {
            _attendantService.UpdateUserPassword(user);
            return RedirectToAction(nameof(GetAllAttendants));
        }

        //Login Attendant
        public IActionResult LoginAttendant()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAttendant(User user)
        {
            var attendant = _attendantService.LoginUser(user);
            if (attendant != null)
            {
                TempData["success"] = "Login Successfully";
                return RedirectToAction("AttendantPage");
            }
            else
            {
                ViewBag.Error = "Incorrect Credential.";
                return View();
            }
        }


    }
}
