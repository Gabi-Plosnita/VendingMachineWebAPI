using VendingMachine.DataAccess.Entities;
using VendingMachine.DataAccess.Exceptions;

namespace VendingMachine.DataAccess.Repository
{
    public class ProductRepository : IRepository
    {
        private static readonly List<Product> ProductsList = new List<Product>
            {
                new Product{
                    Id = 1,
                    Name = "Chocolate",
                    Description = "Chocolate with peanuts",
                    Quantity = 20,
                    Price = 9
                },
                new Product{
                    Id = 2,
                    Name = "Chips",
                    Description = "Chips with salt",
                    Quantity = 7,
                    Price = 5
                },
                new Product{
                    Id = 3,
                    Name = "Still Water",
                    Description = "Pure, clear, and free from carbonation or additives.",
                    Quantity = 10,
                    Price = 2
                },
            };

        public int CreateProduct(Product product)
        {
            product.Id = GetNextId();
            ProductsList.Add(product);
            return product.Id;
        }

        public List<Product> GetProducts()
        {
            return ProductsList;
        }

        public Product GetProduct(int id)
        {
            Product product = ProductsList.FirstOrDefault(product => product.Id == id);
            if (product == null)
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

            Product product = ProductsList.FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                throw new InvalidIdException($"Id {id} is invalid!");
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Quantity = updatedProduct.Quantity;
            product.Price = updatedProduct.Price;
        }

        public void DeleteProduct(int id)
        {
            Product product = ProductsList.FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                throw new InvalidIdException($"Id {id} is invalid!");
            }
            ProductsList.Remove(product);
        }

        public int GetNextId()
        {
            if(ProductsList.Count > 0)
            {
                return ProductsList.Last().Id + 1;
            }
            return 1;
        }

    }

}