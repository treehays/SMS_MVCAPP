using Microsoft.AspNetCore.Mvc;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult TransactionPage()
    {
        return View();
    }

    public IActionResult CreateTransaction()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateTransaction(Transaction transaction)
    {
        _transactionService.CreateTransaction(transaction);
        TempData["success"] = "Successful.";
        return RedirectToAction("Index", "Home");
    }

    public IActionResult GetTransaction(string recieptNo)
    {
        var transaction = _transactionService.GetTransactionsByReceiptNo(recieptNo);
        return View(transaction);
    }

    public IActionResult GetAllTransaction()
    {
        var transaction = _transactionService.GetAllTransactions();
        return View(transaction);
    }

    public IActionResult GetTransactionByStaffId(string staffId)
    {
        var transaction = _transactionService.GetTransactionsByStaffId(staffId);
        return View(transaction);
    }
    
     public IActionResult GetTransactionByCustomerName(string customerName)
     {
         var transaction = _transactionService.GetTransactionsByCustomerId(customerName);
        return View(transaction);
    }
     
     public IActionResult CalculateTotalSales()
     {
         var transaction = _transactionService.CalculateTotalSales();
        return View(transaction);
    }
    
    
}