using Microsoft.AspNetCore.Mvc;
using SMS_MVCAPP.Models.Entities;
using SMS_MVCAPP.Services.Interfaces;

namespace SMS_MVCAPP.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ProductPage()
    {
        return View();
    }

    public IActionResult CreateProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        if (_productService.GetProductByBarCode(product.BarCode) == null)
        {
            _productService.CreateProduct(product);
            TempData["success"] = "Creation Successful.    ";
            return RedirectToAction("Index", "Home");
        }
        else
        {
            TempData["failed"] = "Product Exist";
            return View();
        }
    }

    public IActionResult GetAllProducts()
    {
        var products = _productService.GetAllProducts();
        return View(products);
    }

    public IActionResult GetProductByBarCode(string barCode)
    {
        var product = _productService.GetProductByBarCode(barCode);
        return View(product);
    }
    
    public IActionResult GetProductByCategory(string category)
    {
        var product = _productService.GetProductByCategory(category);
        return View(product);
    }
    
    public IActionResult GetProductByProductName(string productName)
    {
        var product = _productService.GetProductByProductName(productName);
        return View(product);
    }
    
    public IActionResult GetProductByQuantityRemaining(int quantityRemaining)
    {
        var product = _productService.GetProductByQuantityRemaining(quantityRemaining);
        return View(product);
    }

    public IActionResult DeleteProduct(Product product)
    {
        _productService.DeleteProduct(product);
        return RedirectToAction("GetAllProducts");
    }

    public IActionResult DeleteProductConfirmPage(string barCode)
    {
        var product = _productService.GetProductByBarCode(barCode);
        return View(product);
    }

    public IActionResult UpdateProduct(string barCode)
    {
        var product = _productService.GetProductByBarCode(barCode);
        return View(product);
    }
    [HttpPost]
    public IActionResult UpdateProduct(Product product)
    {
        _productService.UpdateProduct(product);
        return RedirectToAction(nameof(GetAllProducts));
    }
    
    public IActionResult UpdateProductQuantity(string barCode)
    {
        var product = _productService.GetProductByBarCode(barCode);
        return View(product);
    }
    
    public IActionResult UpdateProductQuantity(Product product)
    {
        _productService.UpdateProductQuantity(product);
        return RedirectToAction(nameof(GetAllProducts));
    }
    
    
}