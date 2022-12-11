using SMS_MVCAPP.Context;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;

namespace SMS_MVCAPP.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationContext _context;

        public TransactionRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Transaction CreateTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }

        public IList<Transaction> GetAllTransactions()
        {
            var transactions = _context.Transactions.ToList();
            return transactions;
        }

        public IList<Transaction> GetTransactionsByStaffId(string staffId)
        {
            var transactions = _context.Transactions.Where(m => m.StaffId == staffId).ToList();
            return transactions;
        }

        public IList<Transaction> GetTransactionsByCustomerId(string customerName)
        {
            var transactions = _context.Transactions.Where(m => m.CustomerName == customerName).ToList();
            return transactions;
        }

        public IList<Transaction> GetTransactionsByDate(string transactionDate)
        {
            var transactions = _context.Transactions.Where(m => m.TransactionDate == transactionDate).ToList();
            return transactions;
        }

        public Transaction GetTransactionsByReceiptNo(string receiptNo)
        {
         var transaction = _context.Transactions.Find(receiptNo);
            return transaction;
        }

        public decimal CalculateTotalSales()
        {
            var results = _context.Transactions.Sum(m => m.Total);
            return results;
        }

        // public IList<Transaction> ViewTransactionAsExcel(string datedNow)
        // {
        //     var transactions = _context.Transactions.ToList();
        //     return transactions;
        // }
        //
        // public IList<Transaction> ViewTransactionAsHtml(string datedNow)
        // {
        //     
        // }
    }
}
