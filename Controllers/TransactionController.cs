using Microsoft.AspNetCore.Mvc;

namespace SMS_MVCAPP.Controllers;

public class TransactionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}