using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _adminService;
        public AdminController(IUserService adminService)
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
        public IActionResult CreateAdmin(User user)
        {
            if (_adminService.GetUserByEmail(user.Email) == null)
            {
                _adminService.CreateUser(user);
                TempData["sucess"] = "Registrtion Sucessful.    ";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["failed"] = "Registrtion Failed";
                return View();
            }
        }

        //get all admins

        public IActionResult GetAllAdmins()
        {
            var admin = _adminService.GetAllUser();
            return View(admin);
        }

        //get a single admin by stff id
        public IActionResult GetAdminByStaffId(string staffId)
        {
            var admin = _adminService.GetUserByStaffId(staffId);
            return View(admin);
        }

        //get a single admin by email
        public IActionResult GetAdminByEmail(string email)
        {
            var admin = _adminService.GetUserByEmail(email);
            return View(admin);
        }


        //deleting admin
        public IActionResult DeleteAdmin(User user)
        {
            _adminService.DeleteUser(user);
            return RedirectToAction("GetAllAdmins");
        }

        public IActionResult DeleteAdminConfirmPage(string staffId)
        {
            var admin = _adminService.GetUserByStaffId(staffId);
            return View(admin);
        }

        //Updating User
        public IActionResult UpdateAdmin(string staffId)
        {
            var admin = _adminService.GetUserByStaffId(staffId);
            return View(admin);
        }

        [HttpPost]
        public IActionResult UpdateAdmin(User user)
        {
            _adminService.UpdateUser(user);
            return RedirectToAction(nameof(GetAllAdmins));
        }

        //Updating User password
        public IActionResult UpdateAdminPassword(string staffId)
        {
            var admin = _adminService.GetUserByStaffId(staffId);
            return View(admin);
        }

        [HttpPost]
        public IActionResult UpdateAdminPassword(User user)
        {
            _adminService.UpdateUserPassword(user);
            return RedirectToAction(nameof(GetAllAdmins));
        }

        //Login Admin
        public IActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAdmin(User user)
        {
           var admin = _adminService.LoginUser(user);
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