using SMS_MVCAPP.Context;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;

namespace SMS_MVCAPP.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public Product GetProductByBarCode(string barCode)
        {
            var product =  _context.Products.SingleOrDefault(x => x.BarCode == barCode);
            return product;
        }

        public IList<Product> GetProductByProductName(string productName)
        {
            // var listOfProduct = _context.Products.Where(x => x.ProductName == productName).Select(x => x).ToList();
            var products = _context.Products.Where(n => productName.All(m => n.ProductName.Contains(m))).ToList();
            return products;
        }

        public IList<Product> GetProductByCategory(string productCategory)
        {
            var products = _context.Products.Where(m => m.ProductCategory == productCategory).ToList();
            return products;
        }

        public IList<Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public IList<Product> GetProductByQuantityRemaining(int quantity)
        {
            var products = _context.Products.Where(m => m.ProductQuantity <= quantity).ToList();
            return products;
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product UpdateProductQuantity(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public Product RestockProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public int InventoryQuantityAlert()
        {
            var quantityAlert = _context.Products.Count(m => m.ProductQuantity <= 20);
            return quantityAlert;
        }
    }
}