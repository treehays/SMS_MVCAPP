using System.ComponentModel.DataAnnotations;

namespace SMS_MVCAPP.Models.Entities
{
    public class Product
    {
        [Key]
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public decimal SellingPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductCategory { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
