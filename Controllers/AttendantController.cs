using Microsoft.AspNetCore.Mvc;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Services.Implementations;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Controllers
{
    public class AttendantController : Controller
    {
        private readonly IAttendantService _attendantService;
        public AttendantController(IAttendantService attendantService)
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
        public IActionResult CreateAttendant(Attendant attendant)
        {
            if (_attendantService.GetAttendantByEmail(attendant.Email) == null)
            {
                _attendantService.CreateAttendant(attendant);
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
            var attendant = _attendantService.GetAllAttendant();
            return View(attendant);
        }

        //get a single attendant by stff id
        public IActionResult GetAttendantByStaffId(string staffId)
        {
            var attendant = _attendantService.GetAttendantByStaffId(staffId);
            return View(attendant);
        }

        //get a single attendant by email
        public IActionResult GetAttendantByEmail(string email)
        {
            var attendant = _attendantService.GetAttendantByEmail(email);
            return View(attendant);
        }


        //deleting attendant
        public IActionResult DeleteAttendant(Attendant attendant)
        {
            _attendantService.DeleteAttendant(attendant);
            return RedirectToAction("GetAllAttendants");
        }

        public IActionResult DeleteAttendantConfirmPage(string staffId)
        {
            var attendant = _attendantService.GetAttendantByStaffId(staffId);
            return View(attendant);
        }

        //Updating Attendant
        public IActionResult UpdateAttendant(string staffId)
        {
            var attendant = _attendantService.GetAttendantByStaffId(staffId);
            return View(attendant);
        }

        [HttpPost]
        public IActionResult UpdateAttendant(Attendant attendant)
        {
            _attendantService.UpdateAttendant(attendant);
            return RedirectToAction(nameof(GetAllAttendants));
        }

        //Updating Attendant password
        public IActionResult UpdateAttendantPassword(string staffId)
        {
            var attendant = _attendantService.GetAttendantByStaffId(staffId);
            return View(attendant);
        }

        [HttpPost]
        public IActionResult UpdateAttendantPassword(Attendant attendant)
        {
            _attendantService.UpdateAttendantPassword(attendant);
            return RedirectToAction(nameof(GetAllAttendants));
        }

        //Login Attendant
        public IActionResult LoginAttendant()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAttendant(Attendant attendant)
        {
            attendant = _attendantService.LoginAttendant(attendant);
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
