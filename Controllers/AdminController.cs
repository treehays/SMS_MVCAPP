using Microsoft.AspNetCore.Mvc;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Admin Dashboard
        public IActionResult AdminPage()
        {
            return View();
        }


        //creating admin
        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAdmin(Admin admin)
        {
            if (_adminService.GetAdminByEmail(admin.Email) == null)
            {
                _adminService.CreateAdmin(admin);
                TempData["success"] = "Registration Successful.    ";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["failed"] = "Registration Failed";
                return View();
            }
        }

        //get all admins

        public IActionResult GetAllAdmins()
        {
            var admin = _adminService.GetAllAdmin();
            return View(admin);
        }

        //get a single admin by stff id
        public IActionResult GetAdminByStaffId(string staffId)
        {
            var admin = _adminService.GetAdminByStaffId(staffId);
            return View(admin);
        }

        //get a single admin by email
        public IActionResult GetAdminByEmail(string email)
        {
            var admin = _adminService.GetAdminByEmail(email);
            return View(admin);
        }


        //deleting admin
        public IActionResult DeleteAdmin(Admin admin)
        {
            _adminService.DeleteAdmin(admin);
            return RedirectToAction("GetAllAdmins");
        }

        public IActionResult DeleteAdminConfirmPage(string staffId)
        {
            var admin = _adminService.GetAdminByStaffId(staffId);
            return View(admin);
        }

        //Updating Admin
        public IActionResult UpdateAdmin(string staffId)
        {
            var admin = _adminService.GetAdminByStaffId(staffId);
            return View(admin);
        }

        [HttpPost]
        public IActionResult UpdateAdmin(Admin admin)
        {
            _adminService.UpdateAdmin(admin);
            return RedirectToAction(nameof(GetAllAdmins));
        }

        //Updating Admin password
        public IActionResult UpdateAdminPassword(string staffId)
        {
            var admin = _adminService.GetAdminByStaffId(staffId);
            return View(admin);
        }

        [HttpPost]
        public IActionResult UpdateAdminPassword(Admin admin)
        {
            _adminService.UpdateAdminPassword(admin);
            return RedirectToAction(nameof(GetAllAdmins));
        }

        //Login Admin
        public IActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAdmin(Admin admin)
        {
           admin = _adminService.LoginAdmin(admin);
            if (admin != null)
            {
                TempData["success"] = "Login Successfully";
                return RedirectToAction("AdminPage");
            }
            else
            {
                ViewBag.Error = "Incorrect Credential.";
                return View();
            }
        }





    }
}

//scallfold