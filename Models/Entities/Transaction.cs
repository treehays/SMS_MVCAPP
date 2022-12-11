using System.ComponentModel.DataAnnotations;

namespace SMS_MVCAPP.Models.Entities
{
    public class Transaction
    {
        [Key]
        public string ReceiptNo { get; set; }
        public string CustomerName { get; set; }
        public int QuantityPurchased { get; set; }
        public decimal Total { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public string TransactionDate{ get; set; }
        public string PaymentType { get; set; }
        public string StaffId { get; set; }
    }
}
