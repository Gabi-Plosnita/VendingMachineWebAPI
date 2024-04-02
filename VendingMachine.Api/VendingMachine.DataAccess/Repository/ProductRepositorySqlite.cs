using VendingMachine.DataAccess.Entities;
using VendingMachine.DataAccess.Exceptions;

namespace VendingMachine.DataAccess.Repository
{
    public class ProductRepositorySqlite : IRepository
    {
        private readonly VendingMachineDbContext _context;

        public ProductRepositorySqlite(VendingMachineDbContext context)
        {
            _context = context;
        }

        public int CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product.Id;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                throw new InvalidIdException($"Id {id} is invalid!");
            }
            return product;
        }

        public void UpdateProduct(int id, Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                throw new InvalidIdException($"Id {id} is invalid!");
            }

            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new InvalidIdException($"Id {id} is invalid!");
            }

            Product newProduct = new Product
            {
                Id = id,
                Name = updatedProduct.Name,
                Description = updatedProduct.Description,
                Quantity = updatedProduct.Quantity,
                Price = updatedProduct.Price
            };

            _context.Products.Remove(product);
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new InvalidIdException($"Id {id} is invalid!");
            }
            
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

    }
}
