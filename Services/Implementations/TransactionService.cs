using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Services.Implementations;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    
    public Transaction CreateTransaction(Transaction transaction)
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
        var r1 = new Random().Next(25);
        var r2 = new Random().Next(25);
        var guids = Guid.NewGuid().ToString().Remove(5);
         transaction.ReceiptNo = $"REF{guids}{alphabet[r1]}{alphabet[r2]}{new Random().Next(1100000)}";
         transaction.TransactionDate = DateTime.Now.ToString("g");
         _transactionRepository.CreateTransaction(transaction);
         return transaction;


    }
    
    public IList<Transaction> GetAllTransactions()
    {
        var transactions = _transactionRepository.GetAllTransactions();
        return transactions;
    }

    public IList<Transaction> GetTransactionsByStaffId(string staffId)
    {
        var transactions = _transactionRepository.GetTransactionsByStaffId(staffId);
        return transactions;
    }

    public IList<Transaction> GetTransactionsByCustomerId(string customerName)
    {
        var transactions = _transactionRepository.GetTransactionsByCustomerId(customerName);
        return transactions;
    }

    public IList<Transaction> GetTransactionsByDate(string transactionDate)
    {
        var transactions = _transactionRepository.GetTransactionsByDate(transactionDate);
        return transactions;
    }

    public Transaction GetTransactionsByReceiptNo(string receiptNo)
    {
        var transactions = _transactionRepository.GetTransactionsByReceiptNo(receiptNo);
        return transactions;
    }

    public decimal CalculateTotalSales()
    {
        var total = _transactionRepository.CalculateTotalSales();
        return total;
    }
}