using app.Entities;
using app.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace app.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IOptions<config.MongoDBSettings> settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _products = database.GetCollection<Product>(settings.Value.ProductCollectionName);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var serializedProducts = await _products.Find(product => true).ToListAsync();
            return serializedProducts;
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _products.Find(product => product.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _products.DeleteOneAsync(product => product.Id == id);
        }
    }
}
