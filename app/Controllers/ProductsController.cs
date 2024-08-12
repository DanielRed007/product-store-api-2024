using Microsoft.AspNetCore.Mvc;
using app.Entities;

namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Description = "Description A", Price = 10.99m, StockQuantity = 100 },
            new Product { Id = 2, Name = "Product B", Description = "Description B", Price = 20.99m, StockQuantity = 50 }
        };
    }
}
