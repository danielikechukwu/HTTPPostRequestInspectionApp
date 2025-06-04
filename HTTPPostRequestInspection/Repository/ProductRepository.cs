using HTTPPostRequestInspection.Models;

namespace HTTPPostRequestInspection.Repository
{
    public class ProductRepository
    {
        public List<Product> Products = new List<Product>()
        {
            new Product() { Id = 1, Name= "Laptop", Price = 1000, Quantity = 10 },
            new Product() { Id = 2, Name= "Desktop", Price = 2000, Quantity = 20 },

        };

        // Add a New Product and return the newly Created Product Id
        public async Task<int> AddProduct(Product product)
        {
            //Set the Product Id
            product.Id = Products.Count + 1;

            Products.Add(product);

            await Task.Delay(TimeSpan.FromSeconds(3));

            return product.Id;

        }

        // Get a product by Id
        public async Task<Product> GetById(int Id)
        {
            var product = Products.FirstOrDefault(p => p.Id == Id);

            await Task.Delay(TimeSpan.FromSeconds(3));

            return product!;

        }
    }
}
