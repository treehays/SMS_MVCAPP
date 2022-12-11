using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Repositories.Interfaces;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _iProductRepository;

    public ProductService(IProductRepository productRepository)
    {
        _iProductRepository = productRepository;
    }
    
    public Product CreateProduct(Product product)
    {
        product.CreatedDate = DateTime.Now;
        _iProductRepository.CreateProduct(product);
        return product;
    }

    public Product UpdateProduct(Product product)
    {
        var products = _iProductRepository.GetProductByBarCode(product.BarCode);
        products.ProductName = product.ProductName ?? products.ProductName;
        products.ProductQuantity = product.ProductQuantity <= 0 ? products.ProductQuantity : product.ProductQuantity;
        products.ProductCategory = product.ProductCategory ?? products.ProductCategory;
        products.SellingPrice = product.SellingPrice > 0 ? product.SellingPrice : products.SellingPrice;
        _iProductRepository.UpdateProduct(products);
        return products;
    }

    public Product GetProductByBarCode(string barCode)
    {
        var product = _iProductRepository.GetProductByBarCode(barCode);
        return product;
    }

    public IList<Product> GetProductByProductName(string productName)
    {
        var products = _iProductRepository.GetProductByProductName(productName);
        return products;
    }

    public IList<Product> GetProductByCategory(string productCategory)
    {
        var products = _iProductRepository.GetProductByCategory(productCategory);
        return products;
    }

    public IList<Product> GetAllProducts()
    {
        var products = _iProductRepository.GetAllProducts();
        return products;
    }

    public IList<Product> GetProductByQuantityRemaining(int quantity)
    {
        var products = _iProductRepository.GetProductByQuantityRemaining(quantity);
        return products; 
    }

    public void DeleteProduct(Product product)
    {
        product = _iProductRepository.GetProductByBarCode(product.BarCode);
        _iProductRepository.DeleteProduct(product);
    }

    public Product UpdateProductQuantity(Product product)
    {
        var products = _iProductRepository.GetProductByBarCode(product.BarCode);
        products.ProductQuantity = product.ProductQuantity <= 0 ? products.ProductQuantity : product.ProductQuantity;
        return product;
    }

    public Product RestockProduct(Product product)
    {
        var products = _iProductRepository.GetProductByBarCode(product.BarCode);
        products.ProductQuantity = product.ProductQuantity <= 0 ? products.ProductQuantity : (product.ProductQuantity+ products.ProductQuantity);
        return product;
    }

    public int InventoryQuantityAlert()
    {
        var results = _iProductRepository.InventoryQuantityAlert();
        return results;
    }
}