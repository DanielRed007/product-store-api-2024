using Microsoft.AspNetCore.Mvc;
using app.Entities;
using app.Interfaces;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    private readonly IProductRepository _productRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        var products = await _productRepository.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<Product> Get(ObjectId id)
    {
        return await _productRepository.GetProductByIdAsync(id);
    }

    [HttpPost]
    public async Task Post([FromBody] Product product)
    {
        await _productRepository.AddProductAsync(product);
    }

    [HttpPut("{id}")]
    public async Task Put(ObjectId id, [FromBody] Product product)
    {
        product.Id = id;
        await _productRepository.UpdateProductAsync(product);
    }

    [HttpDelete("{id}")]
    public async Task Delete(ObjectId id)
    {
        await _productRepository.DeleteProductAsync(id);
    }
}
