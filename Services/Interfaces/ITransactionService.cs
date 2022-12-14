using SMS_MVCAPP.Models.Entities;

namespace SMS_MVCAPP.Services.Interfaces
{
    public interface ITransactionService
    {
        Transaction CreateTransaction(Transaction transaction);
        IList<Transaction> GetAllTransactions();
        IList<Transaction> GetTransactionsByStaffId(string staffId);
        IList<Transaction> GetTransactionsByCustomerId(string customerName);
        IList<Transaction> GetTransactionsByDate(string transactionDate);
        Transaction GetTransactionsByReceiptNo(string receiptNo);
        decimal CalculateTotalSales();
        // IList<Transaction> ViewTransactionAsExcel(string datedNow);
        // IList<Transaction> ViewTransactionAsHtml(string datedNow);

    }
}
