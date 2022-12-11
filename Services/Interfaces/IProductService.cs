using SMS_MVCAPP.Models.Entities;

namespace SMS_MVCAPP.Services.Interfaces
{
    public interface IProductService
    {
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        Product GetProductByBarCode(string barCode);
        IList<Product> GetProductByProductName(string productName);
        IList<Product> GetProductByCategory(string productCategory);
        IList<Product> GetAllProducts();
        IList<Product> GetProductByQuantityRemaining(int quantity);
        void DeleteProduct(Product product);
        Product UpdateProductQuantity(Product product);
        Product RestockProduct(Product product);
        int InventoryQuantityAlert();
    }
}
